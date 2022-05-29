using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NetTestFramework.Configuration;
using NetTestFramework.Configuration.Enums;

namespace NetTestFramework.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    private static List<User> _users = null!;
    private static AppSettings _appSettings = null!;
    public static IConfiguration Configuration => s_configuration.Value;
    // public static string BaseUrl => Configuration[nameof(BaseUrl)];
    // public static string Username => Configuration[nameof(Username)];
    // public static string Password => Configuration[nameof(Password)];
    // public static string BrowserType => Configuration[nameof(BrowserType)];
    // public static string FileName => Configuration[nameof(FileName)];
    // public static string InputText => Configuration[nameof(InputText)];
    // public static string InputNewText => Configuration[nameof(InputNewText)];
    // public static string CommitNewFile => Configuration[nameof(CommitNewFile)];
    // public static string ConfirmToDelete => Configuration[nameof(ConfirmToDelete)];
    // public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);

    public static User Admin =>
        _users.Find(user => user.UserType == UserType.Admin) ?? throw new NullReferenceException("Data not found. Check your appsetting.json file!");

    public static User User =>
        _users.Find(user => user.UserType == UserType.User) ?? throw new NullReferenceException("Data not found. Check your appsetting.json file!");

    public static AppSettings AppSettings => _appSettings ?? throw new NullReferenceException("Data not found. Check your appsetting.json file!");

    
    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        BuildUsersList();
        BuildAppSettings();
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile("appsettings.json");
        var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");
        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }

    private static void BuildUsersList()
    {
        var usersSection = Configuration.GetSection(nameof(User));
        _users = new List<User>();
        foreach (var usersArrayMember in usersSection.GetChildren())
        {
            var user = new User
            {
                Username = usersArrayMember["Username"],
                Password = usersArrayMember["Password"],
                Token = usersArrayMember["Token"]
            };
            user.UserType = usersArrayMember["UserType"]?.ToLower() switch
            {
                "admin" => UserType.Admin,
                "user" => UserType.User,
                _ => user.UserType
            };
            _users.Add(user);
        }
    }
    
    private static void BuildAppSettings()
    {
        var appSettingsSection = Configuration.GetSection(nameof(AppSettings));
        _appSettings = new AppSettings
        {
            BaseUrl = appSettingsSection["BaseUrl"],
            ApiUrl = appSettingsSection["ApiUrl"],
            BrowserType = appSettingsSection["BrowserType"],
            WaitTimeout = int.Parse(appSettingsSection["WaitTimeout"])
        };
    }
}