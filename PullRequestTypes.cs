using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace UserGroupSample
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Message
    {
        public string Text { get; set; }
        public string Html { get; set; }
        public string Markdown { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public string Visibility { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Repository
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Project Project { get; set; }
        public string DefaultBranch { get; set; }
        public string RemoteUrl { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CreatedBy
    {
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public string UniqueName { get; set; }
        public string ImageUrl { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Reviewer
    {
        public object ReviewerUrl { get; set; }
        public int Vote { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        public string UniqueName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsContainer { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Commit
    {
        public string CommitId { get; set; }
        public string Url { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Link
    {
        public string Href { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Links
    {
        public Link Web { get; set; }
        public Link Statuses { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Resource
    {
        public Repository Repository { get; set; }
        public int PullRequestId { get; set; }
        public string Status { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SourceRefName { get; set; }
        public string TargetRefName { get; set; }
        public string MergeStatus { get; set; }
        public string MergeId { get; set; }
        public Commit LastMergeSourceCommit { get; set; }
        public Commit LastMergeTargetCommit { get; set; }
        public Commit LastMergeCommit { get; set; }
        public List<Reviewer> Reviewers { get; set; }
        public List<Commit> Commits { get; set; }
        public string Url { get; set; }
        public Links _Links { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Entity
    {
        public string Id { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ResourceContainers
    {
        public Entity Collection { get; set; }
        public Entity Account { get; set; }
        public Project Project { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PullRequestPayload
    {
        public string SubscriptionId { get; set; }
        public int NotificationId { get; set; }
        public string Id { get; set; }
        public string EventType { get; set; }
        public string PublisherId { get; set; }
        public Message Message { get; set; }
        public Message DetailedMessage { get; set; }
        public Resource Resource { get; set; }
        public string ResourceVersion { get; set; }
        public ResourceContainers ResourceContainers { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PRUpdatedResource
    {
        public Repository Repository { get; set; }
        public int PullRequestId { get; set; }
        public int CodeReviewId { get; set; }
        public string Status { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string SourceRefName { get; set; }
        public string TargetRefName { get; set; }
        public string MergeStatus { get; set; }
        public bool IsDraft { get; set; }
        public string MergeId { get; set; }
        public Commit LastMergeSourceCommit { get; set; }
        public Commit LastMergeTargetCommit { get; set; }
        public Commit LastMergeCommit { get; set; }
        public List<object> Reviewers { get; set; }
        public string Url { get; set; }
        public Links _Links { get; set; }
        public bool SupportsIterations { get; set; }
        public string ArtifactId { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PRUpdated
    {
        public string SubscriptionId { get; set; }
        public int NotificationId { get; set; }
        public string Id { get; set; }
        public string EventType { get; set; }
        public string PublisherId { get; set; }
        public Message Message { get; set; }
        public Message EetailedMessage { get; set; }
        public PRUpdatedResource Resource { get; set; }
        public string ResourceVersion { get; set; }
        public ResourceContainers ResourceContainers { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class StatusUpdate
    {
        public string State { get; set; }
        public string Description { get; set; }
        public Context Context { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Context
    {
        public string Name { get; set; }
        public string Genre { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Iteration
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool HasMoreCommits { get; set; }
        public string Reason { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Iterations
    {
        public List<Iteration> Value { get; set; }
        public int Count { get; set; }
    }
}