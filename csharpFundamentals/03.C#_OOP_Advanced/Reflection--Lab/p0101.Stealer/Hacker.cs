﻿public class Hacker
{
    public string username = "securityGod82";
    private string password = "mySuperSecretPassw0rd";

    private int Id { get; set; }

    public string Password
    {
        get => this.password;
        set => this.password = value;
    }

    public double BankAccountBalance { get; private set; }

    public void DownloadAllBankAccountsInTheWorld()
    {
    }
}
