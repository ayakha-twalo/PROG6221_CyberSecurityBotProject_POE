using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        // Dictionary storing keywords and responses
        private Dictionary<string, List<string>> responses;

        private Random random = new Random();

        public KeywordResponder()
        {
            responses = new Dictionary<string, List<string>>()
            {
                {
                    "password",
                    new List<string>
                    {
                        "Use strong passwords with letters, numbers, and symbols.",

                        "Avoid using personal details like your birthday in passwords.",

                        "Use different passwords for different accounts to stay safer online.",

                        "A password manager can help you store secure passwords safely.",

                        // LONG RESPONSE
                        "Passwords are one of the most important parts of online security. " +
                        "A strong password should be at least 12 characters long and include a mix of letters, numbers, and symbols. " +
                        "Avoid using personal information like your name or birthday because hackers can easily guess them. " +
                        "It is also important to use different passwords for each account so that if one account is hacked, the others remain protected."
                    }
                },

                {
                    "phishing",
                    new List<string>
                    {
                        "Be careful of emails asking for personal information.",

                        "Avoid clicking suspicious links from unknown senders.",

                        "Check email addresses carefully before trusting messages.",

                        "Phishing scams often pretend to be trusted companies.",

                        // LONG RESPONSE
                        "Phishing is a type of scam where attackers trick people into giving away personal information such as passwords or banking details. " +
                        "These attacks often happen through fake emails, messages, or websites that look real. " +
                        "Always verify links before clicking them and never rush into giving personal information online."
                    }
                },

                {
                    "privacy",
                    new List<string>
                    {
                        "Review your privacy settings on social media regularly.",

                        "Avoid sharing personal information publicly online.",

                        "Be careful about accepting friend requests from strangers.",

                        "The less information you share online, the safer you are.",

                        // LONG RESPONSE
                        "Online privacy is about protecting your personal information while using the internet. " +
                        "Many apps and websites collect data about your location, interests, and activity. " +
                        "To stay safe, limit what you share online and regularly review the privacy settings on your accounts."
                    }
                },

                {
                    "scam",
                    new List<string>
                    {
                        "Be suspicious of offers that seem too good to be true.",

                        "Never share banking details with unknown people online.",

                        "Scammers often create urgency to pressure victims.",

                        "Always verify messages before responding to them.",

                        // LONG RESPONSE
                        "Online scams are attempts by criminals to steal money or personal information. " +
                        "Scammers often pretend to be trusted companies or people you know. " +
                        "To stay safe, verify suspicious messages and avoid sharing sensitive information online."
                    }
                },

                {
                    "malware",
                    new List<string>
                    {
                        "Avoid downloading files from unknown websites.",

                        "Keep your antivirus software updated regularly.",

                        "Malware can damage devices or steal personal information.",

                        "Do not install cracked or suspicious software.",

                        // LONG RESPONSE
                        "Malware is harmful software designed to damage devices or steal information. " +
                        "It can spread through unsafe downloads, infected email attachments, or fake websites. " +
                        "Always keep your system updated and avoid downloading files from untrusted sources."
                    }
                },

                {
                    "2fa",
                    new List<string>
                    {
                        "Enable 2FA on important accounts for extra security.",

                        "2FA adds another layer of protection beyond passwords.",

                        "Authentication apps are safer than SMS codes.",

                        "2FA helps protect accounts even if passwords are stolen.",

                        // LONG RESPONSE
                        "Two-factor authentication adds extra security to your online accounts. " +
                        "After entering your password, you must confirm your identity using another method such as a code sent to your phone. " +
                        "This makes it much harder for attackers to access your account."
                    }
                },

                {
                    "safe browsing",
                    new List<string>
                    {
                        "Only visit websites that use HTTPS security.",

                        "Avoid clicking suspicious ads and pop-ups.",

                        "Keep your browser updated for better security.",

                        "Download files only from trusted websites.",

                        // LONG RESPONSE
                        "Safe browsing means using the internet carefully and securely. " +
                        "Always visit trusted websites and avoid suspicious links or downloads. " +
                        "Secure websites usually begin with HTTPS which helps protect your information online."
                    }
                },

                {
                    "wifi",
                    new List<string>
                    {
                        "Public WiFi networks are not always secure.",

                        "Avoid online banking while using public WiFi.",

                        "Use a VPN for extra protection on public networks.",

                        "Attackers can intercept data on unsecured WiFi networks.",

                        // LONG RESPONSE
                        "Public WiFi can be dangerous because attackers may intercept your internet activity. " +
                        "Avoid logging into important accounts while using public networks and use a VPN whenever possible to protect your information."
                    }
                },

                {
                    "social media",
                    new List<string>
                    {
                        "Set social media accounts to private when possible.",

                        "Avoid posting sensitive personal information online.",

                        "Be careful when accepting friend requests from strangers.",

                        "Think carefully before sharing your location online.",

                        // LONG RESPONSE
                        "Social media safety is about protecting your identity and personal information online. " +
                        "Attackers often gather information from social media to target users with scams or phishing attacks. " +
                        "Review your privacy settings and avoid oversharing personal details."
                    }
                }
            };
        }

        // RANDOM SHORT RESPONSE
        public string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var item in responses)
            {
                if (input.Contains(item.Key))
                {
                    // RANDOM between first 4 responses ONLY
                    int randomIndex = random.Next(0, 4);

                    return item.Value[randomIndex];
                }
            }

            return null;
        }

        // Get detected topic
        public string GetTopic(string input)
        {
            input = input.ToLower();

            foreach (var item in responses)
            {
                if (input.Contains(item.Key))
                {
                    return item.Key;
                }
            }

            return "";
        }

        // LONG RESPONSE ONLY
        public string GetAnotherResponse(string topic)
        {
            if (responses.ContainsKey(topic))
            {
                // Index 4 = LONG response
                return responses[topic][4];
            }

            return "I don't have more information on that topic yet.";
        }

        // Return all keywords
        public List<string> GetAllKeywords()
        {
            return new List<string>(responses.Keys);
        }
    }
}