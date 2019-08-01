# 结合 NLog 搭建 ELK 实时日志分析平台

>  标题貌似有点儿夸大了 😅，准确来说只是一个实践的 Demo 而已。

软件环境：

1. Elasticsearch 7.2.0
2. Kibana 7.2.0
3. Logstash 7.2.0
4. Windows 10 Operating System

关于软件的安装，特别简单，就不废话了（包括配置JDK，安装为 Windows 服务等等，还请自行百度）。

项目顺手也玩了一把 [Web API Selft-Host][owin_web_api_self_host] （官方 Demo）。搭建过程遇到的最大问题，应该是  Logstash 的配置，其余都还好，花了点儿时间简单学习一下配置（足够应付 Demo 了）。Logstash 的配置文件放在了 Configs目录下，其中使用的插件有 [Grok][logstash_grok]、[Date][logstash_date]、[Multiline codec][logstash_multiline_codec]，下面一一说明一下插件用途：

1. 使用 [Grok][logstash_grok] 插件提供的正则表达式来分割 **message** 字段消息，[Grok][logstash_grok] 提供了 [120个默认的正则表达式][logstash_grok_patterns]。
2. 使用 [Date][logstash_date] 插件来重新赋值 **@timestamp** 字段，方便查询。
3. 使用 [Multiline codec][logstash_multiline_codec] 插件来决定当传递过来的消息为多行时（异常堆栈消息）如何处理，目的为合并消息。

关于 ELK 安全验证，请查看：[ELK日志系统+x-pack安全验证](https://www.cnblogs.com/spll/p/9829094.html)

最后附上一句话：**Remember: if a new user has a bad time, it's a bug in logstash** 😁

[owin_web_api_self_host]: https://docs.microsoft.com/en-us/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api	"Use OWIN to Self-Host ASP.NET Web API"
[logstash_grok]: https://www.elastic.co/guide/en/logstash/current/plugins-filters-grok.html	"Grok filter Plugin"
[logstash_date]: https://www.elastic.co/guide/en/logstash/current/plugins-filters-date.html	"Date filter plugin"
[logstash_multiline_codec]: https://www.elastic.co/guide/en/logstash/current/plugins-codecs-multiline.html	"Multiline codec plugin"
[logstash_grok_patterns]: https://github.com/logstash-plugins/logstash-patterns-core/tree/master/patterns "Grok Filter Patterns"