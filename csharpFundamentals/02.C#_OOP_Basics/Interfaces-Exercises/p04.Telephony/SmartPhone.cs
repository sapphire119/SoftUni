using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class SmartPhone : IBrowseable, ICallable
{
    private const string phonePattern = @"^\d+$";
    private const string webPattern = @"^[^0-9\s]+$";


    private List<string> phoneNumbers = new List<string>();
    private List<string> websites = new List<string>();

    public SmartPhone(List<string> phoneNumbers, List<string> websites)
    {
        this.phoneNumbers = phoneNumbers;
        this.websites = websites;
    }

    public IReadOnlyCollection<string> PhoneNumbers => this.phoneNumbers;

    public IReadOnlyCollection<string> Websites => this.websites;

    public string BrowseInternet()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var website in this.Websites)
        {
            if (CheckIfWebsiteIsValid(website))
            {
                sb.AppendLine($"Browsing: {website}!");
            }
            else
            {
                sb.AppendLine($"Invalid URL!");
            }
            //if (Regex.IsMatch(website.Trim(), webPattern))
            //{
            //    sb.AppendLine($"Browsing: {website}!");
            //}
            //else
            //{
            //    sb.AppendLine($"Invalid URL!");
            //}
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private bool CheckIfWebsiteIsValid(string website)
    {
        foreach (var letter in website)
        {
            if (char.IsDigit(letter))
            {
                return false;
            }
        }

        return true;
    }

    public string CallOtherPhones()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var phoneNumber in this.PhoneNumbers)
        {
            if (CheckIfvalidPhoneNumber(phoneNumber))
            {
                sb.AppendLine($"Calling... {phoneNumber}");
            }
            else
            {
                sb.AppendLine($"Invalid number!");
            }
            //if (Regex.IsMatch(phoneNumber.Trim(), phonePattern))
            //{
            //    sb.AppendLine($"Calling... {phoneNumber}");
            //}
            //else
            //{
            //    sb.AppendLine($"Invalid number!");
            //}
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private bool CheckIfvalidPhoneNumber(string phoneNumber)
    {
        foreach (var letter in phoneNumber)
        {
            if (!char.IsDigit(letter))
            {
                return false;
            }
        }
        return true;
    }
}
