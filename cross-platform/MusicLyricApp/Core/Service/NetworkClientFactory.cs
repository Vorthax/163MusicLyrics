using System;
using System.Net;
using System.Net.Http;
using MusicLyricApp.Models;

namespace MusicLyricApp.Core.Service;

public static class NetworkClientFactory
{
    private static NetworkProxyModeEnum _proxyMode = NetworkProxyModeEnum.SYSTEM_PROXY;
    private static string _proxyHost = "";
    private static int _proxyPort = 80;
    private static string _proxyUsername = "";
    private static string _proxyPassword = "";

    public static void Configure(NetworkProxyModeEnum mode)
    {
        _proxyMode = mode;
    }

    public static void Configure(ConfigBean config)
    {
        Configure(config.NetworkProxyMode, config.ProxyHost, config.ProxyPort, config.ProxyUsername, config.ProxyPassword);
    }

    public static void Configure(NetworkProxyModeEnum mode, string? host, int port, string? username, string? password)
    {
        _proxyMode = mode;
        _proxyHost = host?.Trim() ?? "";
        _proxyPort = port;
        _proxyUsername = username ?? "";
        _proxyPassword = password ?? "";
    }

    public static HttpClient CreateHttpClient(int timeoutSeconds = 30)
    {
        var handler = new HttpClientHandler();
        ApplyProxyMode(handler);

        return new HttpClient(handler, disposeHandler: true)
        {
            Timeout = TimeSpan.FromSeconds(timeoutSeconds)
        };
    }

    public static void ConfigureWebClient(WebClient client)
    {
        if (_proxyMode == NetworkProxyModeEnum.DIRECT_CONNECT)
        {
            client.Proxy = null;
            return;
        }

        if (_proxyMode == NetworkProxyModeEnum.HTTP_PROXY)
        {
            var proxy = BuildHttpProxy();
            client.Proxy = proxy;
            return;
        }

        client.Proxy = WebRequest.DefaultWebProxy;
    }

    private static void ApplyProxyMode(HttpClientHandler handler)
    {
        if (_proxyMode == NetworkProxyModeEnum.DIRECT_CONNECT)
        {
            handler.UseProxy = false;
            handler.Proxy = null;
            return;
        }

        if (_proxyMode == NetworkProxyModeEnum.HTTP_PROXY)
        {
            var proxy = BuildHttpProxy();
            if (proxy == null)
            {
                handler.UseProxy = false;
                handler.Proxy = null;
                return;
            }

            handler.UseProxy = true;
            handler.Proxy = proxy;
            return;
        }

        handler.UseProxy = true;
        handler.Proxy = WebRequest.DefaultWebProxy;
    }

    private static IWebProxy? BuildHttpProxy()
    {
        if (string.IsNullOrWhiteSpace(_proxyHost) || _proxyPort <= 0)
        {
            return null;
        }

        var proxy = new WebProxy(new Uri($"http://{_proxyHost}:{_proxyPort}"));
        if (!string.IsNullOrWhiteSpace(_proxyUsername))
        {
            proxy.Credentials = new NetworkCredential(_proxyUsername, _proxyPassword ?? "");
        }

        return proxy;
    }
}
