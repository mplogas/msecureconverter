using System;
using System.Collections.Generic;
using System.Text;

namespace PassConverter
{
    internal class Entry : IEntry
    {
        #region properties
        internal string Group { get; set; }
        internal string Type { get; set; }
        internal string Name { get; set; }
        internal string Url { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }
        internal string Extra1 { get; set; }
        internal string Extra2 { get; set; }
        internal string Extra3 { get; set; }
        internal string Extra4 { get; set; }
        #endregion

        #region ctor
        internal Entry(string group, string type, string name, string url, string username, string password, string extra1, string extra2, string extra3, string extra4)
        {
            Group = group;
            Type = type;
            Name = name;
            Url = url;
            Username = username;
            Password = password;
            Extra1 = extra1;
            Extra2 = extra2;
            Extra3 = extra3;
            Extra4 = extra4;
        }

        internal Entry(IList<string> array)
        {
            if (array[1].Equals(Constants.Accounts))
            {
                Name = array[2];
                Type = array[1];
                Group = array[0];
                Username = array[4];
                Url = @"http://sn";
                Password = array[5];
                Extra1 = array[3];
                Extra2 = array[6];
                Extra3 = array[7];
            } 
            else if (array[1].Equals(Constants.Web))
            {
                Group = array[0];
                Type = array[1];
                Name = array[2];
                Url = String.IsNullOrEmpty(array[4]) ? @"http://sn" : array[4];
                Username = array[5];
                Password = array[6];

            } 
            else if (array[1].Equals(Constants.Games))
            {
                Group = array[0];
                Type = array[1];
                Name = array[2];
                Url = @"http://sn";
                Username = array[4];
                Password = array[5];
            }
            else if (array[1].Equals(Constants.Servers))
            {
                Name = array[2];
                Type = array[1];
                Group = array[0];
                Username = array[5];
                Url = @"http://sn";
                Password = array[6];
                Extra1 = array[3];
                Extra2 = array[4];
                Extra3 = array[7];
                Extra4 = array[8];
            }
            else if (array[1].Equals(Constants.Email))
            {
                Name = array[2];
                Type = array[1];
                Group = array[0];
                Username = array[4];
                Url = @"http://sn";
                Password = array[5];
                Extra1 = array[3];
                Extra2 = array[6];
                Extra3 = array[7];
                Extra4 = array[8];
            }
            else if (array[1].Equals(Constants.CreditCard))
            {
                Name = array[2];
                Type = array[1];
                Group = array[0];
                Username = array[4];
                Url = @"http://sn";
                Password = array[7];
                Extra1 = array[6];
                Extra2 = array[5];
                Extra3 = array[8];
                Extra4 = array[9];
            }
            else if (array[1].Equals(Constants.Messenger))
            {
                Name = array[2];
                Type = array[1];
                Group = array[0];
                Username = array[4];
                Url = @"http://sn";
                Password = array[5];
                Extra1 = array[3];
                Extra2 = array[6];
                Extra3 = array[7];
                Extra4 = array[8];
            }
            else
            {
                Console.WriteLine(array[1]);
            }
        }
        #endregion

        public string ToCSVString()
        {
            var sb = new StringBuilder();

            switch (Type)
            {
                case Constants.Web:
                    //uri
                    sb.Append(Sanitize(Url));
                    sb.Append(Constants.OutputDelimiter);
                    //type
                    sb.Append(Sanitize(Type));
                    sb.Append(Constants.OutputDelimiter);
                    //username
                    sb.Append(Sanitize(Username));
                    sb.Append(Constants.OutputDelimiter);
                    //password
                    sb.Append(Password);
                    sb.Append(Constants.OutputDelimiter);
                    //hostname
                    sb.Append(Constants.OutputDelimiter);
                    //extra
                    sb.Append(CombineExtras());
                    sb.Append(Constants.OutputDelimiter);
                    //name
                    sb.Append(Name);
                    sb.Append(Constants.OutputDelimiter);
                    //group
                    sb.Append(Type);
                    break;
                default://uri
                    sb.Append(Sanitize(Url));
                    sb.Append(Constants.OutputDelimiter);
                    //type
                    sb.Append(Sanitize(Type));
                    sb.Append(Constants.OutputDelimiter);
                    //username
                    sb.Append(Constants.OutputDelimiter);
                    //password
                    sb.Append(Constants.OutputDelimiter);
                    //hostname
                    sb.Append(Constants.OutputDelimiter);
                    //extra
                    sb.Append(CombineExtras());
                    sb.Append(Constants.OutputDelimiter);
                    //name
                    sb.Append(Name);
                    sb.Append(Constants.OutputDelimiter);
                    //group
                    sb.Append(Type);
                    break;
            }

            return sb.ToString();
        }

        #region helper
        private string Sanitize(string s)
        {
            if (s.Contains(Constants.OutputDelimiter)) s = s.Replace(Constants.OutputDelimiter, Constants.Replace);
            if (s.Contains("\\n")) s = s.Replace("\\n", " ");
            return s;
        }

        private string CombineExtras()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty(Username)) sb.Append("user: " + Sanitize(Username) + Constants.ExtrasSeparator);
            if (!String.IsNullOrEmpty(Password)) sb.Append("pass: " + Password + Constants.ExtrasSeparator);
            if (!String.IsNullOrEmpty(Extra1)) sb.Append("extra1: " + Sanitize(Extra1) + Constants.ExtrasSeparator);
            if (!String.IsNullOrEmpty(Extra2)) sb.Append("extra2: " + Sanitize(Extra2) + Constants.ExtrasSeparator);
            if (!String.IsNullOrEmpty(Extra3)) sb.Append("extra3: " + Sanitize(Extra3) + Constants.ExtrasSeparator);
            if (!String.IsNullOrEmpty(Extra4)) sb.Append("extra4: " + Sanitize(Extra4) + Constants.ExtrasSeparator);

            return sb.ToString();
        }
        #endregion
    }

    public interface IEntry
    {
        string ToCSVString();
    }
}