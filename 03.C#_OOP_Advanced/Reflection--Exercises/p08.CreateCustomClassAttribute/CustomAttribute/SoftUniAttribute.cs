using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    private string author;
    private int revisions;
    private string description;
    private string[] reviewers;

    public SoftUniAttribute(string author, string description, int revisions, params string[] reviewers)
    {
        this.Author = author;
        this.Description = description;
        this.Revisions = revisions;
        this.Reviewers = reviewers;
    }

    public string[] Reviewers
    {
        get
        {
            return this.reviewers;
        }
        private set
        {
            this.reviewers = value;
        }
    }

    public string Description
    {
        get
        {
            return this.description;
        }
        private set
        {
            this.description = value;
        }
    }

    public int Revisions
    {
        get
        {
            return this.revisions;
        }
        private set
        {
            this.revisions = value;
        }
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        private set
        {
            this.author = value;
        }
    }

}