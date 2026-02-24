using System;
using System.Net;
using System.Net.Http;
using MusicLyricApp.Models;

namespace MusicLyricApp.Core.Service;

public static class NetworkClientFactory
{
    private static NetworkProxyModeEnum _proxyMode = NetworkProxyModeEnum.SYSTEM_PROXY;

    public static void Configure(NetworkProxyModeEnum mode)
    {
        _proxyMode = mode;
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

        handler.UseProxy = true;
        handler.Proxy = WebRequest.DefaultWebProxy;
    }
}
