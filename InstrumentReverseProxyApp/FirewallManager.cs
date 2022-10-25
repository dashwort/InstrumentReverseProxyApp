using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstrumentReverseProxyApp.models;
using NetFwTypeLib;

namespace InstrumentReverseProxyApp
{
    public class FirewallManager
    {
        public FirewallManager()
        {

        }

        public enum FirewallProfiles
        {
            Domain = 1,
            Private = 2,
            Public = 4, 
            Current = -1
        }

        public enum FirewallProtocol
        {
            TCP = 6,
            UDP = 17,
            Any = 256
        }
        
        public string AddFirewallRule(string ports, FirewallProtocol protocol, FirewallProfiles profile = FirewallProfiles.Current, bool isOutbound = false)
        {
            string ruleName = $"IPAS-{ports}-Inbound";
            
            if (isOutbound)
                ruleName = $"IPAS-{ports}-Outbound";

            if (CheckRuleExists(ruleName))
                return $"Rule: {ruleName} already exists";

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

            var currentFirewallProfiles = firewallPolicy.CurrentProfileTypes;
            firewallRule.Profiles = (int)currentFirewallProfiles;

            // set firewall profile, default is to allow all profiles
            if (profile != FirewallProfiles.Current)
                   firewallRule.Profiles = (int)profile;

            if (isOutbound)
                firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;

            firewallRule.Description = $"Instrument Reverse Proxy rule {ports}";
            firewallRule.Name = ruleName;
            
            firewallRule.Enabled = true;
            firewallRule.InterfaceTypes = "All";
            
            firewallRule.Protocol = (int)protocol;
            firewallRule.LocalPorts = ports;

            firewallPolicy.Rules.Add(firewallRule);

            return firewallRule.Name;
        }

        public void RemoveFirewallRules(string ruleName)
        {
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;

                // List rules
                List<INetFwRule> RuleList = new List<INetFwRule>();

                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    
                    
                    if (rule.Name.IndexOf(ruleName) != -1)
                    {
                        // Now add the rule
                        INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                        firewallPolicy.Rules.Remove(rule.Name);
                        Console.WriteLine(rule.Name + " has been deleted from Firewall Policy");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error delete rule from firewall: {ex.Message}");
            }
        }
        
        public bool CheckRuleExists(string ruleName)
        {          
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;

                // List rules
                List<INetFwRule> RuleList = new List<INetFwRule>();

                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    if (rule.Name.IndexOf(ruleName) != -1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error delete rule from firewall: {ex.Message}");
            }

            return false;
        }

        public void ListFirewallRules()
        {
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;

                // List rules
                List<INetFwRule> RuleList = new List<INetFwRule>();

                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    Console.WriteLine(rule.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listing rules from firewall: {ex.Message}");
            }
        }

        public void AddRuleFromProxy(ProxyEntry proxy)
        {
            AddFirewallRule(proxy.LocalPort.ToString(), FirewallProtocol.TCP);
            AddFirewallRule(proxy.LocalPort.ToString(), FirewallProtocol.TCP, FirewallProfiles.Current, true);
        }
    }
}
