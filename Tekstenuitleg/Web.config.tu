<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="urlrewritingnet" restartOnExternalChanges="true" requirePermission="false" type="UrlRewritingNet.Configuration.UrlRewriteSection, UrlRewritingNet.UrlRewriter" />
    <section name="microsoft.scripting" type="Microsoft.Scripting.Hosting.Configuration.Section, Microsoft.Scripting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="false" />
    <section name="clientDependency" type="ClientDependency.Core.Config.ClientDependencySection, ClientDependency.Core" />
    <section name="Examine" type="Examine.Config.ExamineSettings, Examine" />
    <section name="ExamineLuceneIndexSets" type="UmbracoExamine.Config.ExamineLuceneIndexes, UmbracoExamine" />
    <section name="ImageGenConfiguration" type="ImageGen.ImageGenConfigurationHandler,ImageGen" />
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,Log4net" />
    <!-- Added in Umbraco 4.6.2 -->
    <sectionGroup name="system.web.webPages.razor" type="System.Web.WebPages.Razor.Configuration.RazorWebSectionGroup, System.Web.WebPages.Razor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35">
      <section name="host" type="System.Web.WebPages.Razor.Configuration.HostSection, System.Web.WebPages.Razor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" />
      <section name="pages" type="System.Web.WebPages.Razor.Configuration.RazorPagesSection, System.Web.WebPages.Razor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" requirePermission="false" />
    </sectionGroup>
    <!-- End of added in Umbraco 4.6.2 -->
  </configSections>
  <ImageGenConfiguration configSource="config\ImageGen.config" />
  <urlrewritingnet configSource="config\UrlRewriting.config" />
  <microsoft.scripting configSource="config\scripting.config" />
  <clientDependency configSource="config\ClientDependency.config" />
  <Examine configSource="config\ExamineSettings.config" />
  <ExamineLuceneIndexSets configSource="config\ExamineIndex.config" />
  <appSettings>
    <add key="umbracoDbDSN" value="server=localhost;database=Vanloentu;user id=tuuser;password=smeerkaas" />
    <add key="umbracoConfigurationStatus" value="4.7.1" />
    <add key="umbracoReservedUrls" value="~/config/splashes/booting.aspx,~/install/default.aspx,~/config/splashes/noNodes.aspx,~/test.aspx,~/GetDates.aspx" />
    <add key="umbracoReservedPaths" value="~/umbraco,~/install/" />
    <add key="umbracoContentXML" value="~/App_Data/umbraco.config" />
    <add key="umbracoStorageDirectory" value="~/App_Data" />
    <add key="umbracoPath" value="~/umbraco" />
    <add key="umbracoEnableStat" value="false" />
    <add key="umbracoHideTopLevelNodeFromPath" value="true" />
    <add key="umbracoEditXhtmlMode" value="true" />
    <add key="umbracoUseDirectoryUrls" value="true" />
    <add key="umbracoDebugMode" value="true" />
    <add key="umbracoTimeOutInMinutes" value="20" />
    <add key="umbracoVersionCheckPeriod" value="7" />
    <add key="umbracoDisableXsltExtensions" value="true" />
    <add key="umbracoDefaultUILanguage" value="en" />
    <add key="umbracoProfileUrl" value="profiler" />
    <add key="umbracoUseSSL" value="false" />
    <add key="umbracoUseMediumTrust" value="false" />
    <!-- 
        Set this to true to enable storing the xml cache locally to the IIS server even if the app files are stored centrally on a SAN/NAS 
        Alex Norcliffe 2010 02 for 4.1 -->
    <add key="umbracoContentXMLUseLocalTemp" value="false" />
    <!-- Added in Umbraco 4.6.2 -->
    <add key="webpages:Enabled" value="false" />
    <add key="enableSimpleMembership" value="false" />
    <add key="autoFormsAuthentication" value="false" />
    <!-- End of added in Umbraco 4.6.2 -->
  </appSettings>
  <system.net>
    <mailSettings>
      <smtp>
        <network host="127.0.0.1" userName="username" password="password" />
      </smtp>
    </mailSettings>
  </system.net>
  <connectionStrings>
    <remove name="LocalSqlServer" />
    <!--<add name="LocalSqlServer" connectionString="server=.\sqlexpress;database=aspnetdb;user id=DBUSER;password=DBPASSWORD" providerName="System.Data.SqlClient"/>-->
  </connectionStrings>
  <system.web>
    <customErrors mode="Off" />
    <trace enabled="true" requestLimit="10" pageOutput="false" traceMode="SortByTime" localOnly="false" />
    <sessionState mode="InProc" stateConnectionString="tcpip=127.0.0.1:42424" sqlConnectionString="data source=127.0.0.1;Trusted_Connection=yes" cookieless="false" timeout="20" />
    <globalization requestEncoding="UTF-8" responseEncoding="UTF-8" />
    <xhtmlConformance mode="Strict" />
    <httpRuntime requestValidationMode="2.0" />
    <pages enableEventValidation="false">
      <!-- ASPNETAJAX -->
      <controls>
        <add tagPrefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add tagPrefix="umbraco" namespace="umbraco.presentation.templateControls" assembly="umbraco" />
        <add tagPrefix="asp" namespace="System.Web.UI.WebControls" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      </controls>
    </pages>
    <httpModules>
      <!-- URL REWRTIER -->
      <add name="UrlRewriteModule" type="UrlRewritingNet.Web.UrlRewriteModule, UrlRewritingNet.UrlRewriter" />
      <add name="umbracoRequestModule" type="umbraco.presentation.requestModule" />
      <!-- UMBRACO -->
      <add name="viewstateMoverModule" type="umbraco.presentation.viewstateMoverModule" />
      <add name="umbracoBaseRequestModule" type="umbraco.presentation.umbracobase.requestModule" />
      <!-- ASPNETAJAX -->
      <add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <!-- CLIENT DEPENDENCY -->
      <add name="ClientDependencyModule" type="ClientDependency.Core.Module.ClientDependencyModule, ClientDependency.Core" />
    </httpModules>
    <httpHandlers>
      <remove verb="*" path="*.asmx" />
      <!-- ASPNETAJAX -->
      <add verb="*" path="*.asmx" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" validate="false" />
      <add verb="*" path="*_AppService.axd" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" validate="false" />
      <add verb="GET,HEAD" path="ScriptResource.axd" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" validate="false" />
      <!-- UMBRACO CHANNELS -->
      <add verb="*" path="umbraco/channels.aspx" type="umbraco.presentation.channels.api, umbraco" />
      <add verb="*" path="umbraco/channels/word.aspx" type="umbraco.presentation.channels.wordApi, umbraco" />
      <add verb="*" path="DependencyHandler.axd" type="ClientDependency.Core.CompositeFiles.CompositeDependencyHandler, ClientDependency.Core " />
      <add verb="GET,HEAD,POST" path="GoogleSpellChecker.ashx" type="umbraco.presentation.umbraco_client.tinymce3.plugins.spellchecker.GoogleSpellChecker,umbraco" />
    </httpHandlers>
    <compilation debug="true" batch="false" defaultLanguage="c#" targetFramework="4.0">
      <assemblies>
        <add assembly="System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
        <add assembly="System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
        <add assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add assembly="System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
        <add assembly="System.Data.DataSetExtensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
        <add assembly="System.Web.Extensions.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add assembly="System.Web.Abstractions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
      </assemblies>
      <buildProviders>
        <add extension=".cshtml" type="umbraco.MacroEngines.RazorBuildProvider, umbraco.MacroEngines" />
        <add extension=".vbhtml" type="umbraco.MacroEngines.RazorBuildProvider, umbraco.MacroEngines" />
        <add extension=".razor" type="umbraco.MacroEngines.RazorBuildProvider, umbraco.MacroEngines" />
      </buildProviders>
    </compilation>
    <authentication mode="Forms">
      <forms name="yourAuthCookie" loginUrl="login.aspx" protection="All" path="/" />
    </authentication>
    <authorization>
      <allow users="?" />
    </authorization>
    <!-- Membership Provider -->
    <membership defaultProvider="UmbracoMembershipProvider" userIsOnlineTimeWindow="15">
      <providers>
        <clear />
        <add name="UmbracoMembershipProvider" type="umbraco.providers.members.UmbracoMembershipProvider" enablePasswordRetrieval="false" enablePasswordReset="false" requiresQuestionAndAnswer="false" defaultMemberTypeAlias="Another Type" passwordFormat="Hashed" />
        <add name="UsersMembershipProvider" type="umbraco.providers.UsersMembershipProvider" enablePasswordRetrieval="false" enablePasswordReset="false" requiresQuestionAndAnswer="false" passwordFormat="Hashed" />
      </providers>
    </membership>
    <!-- added by NH to support membership providers in access layer -->
    <roleManager enabled="true" defaultProvider="UmbracoRoleProvider">
      <providers>
        <clear />
        <add name="UmbracoRoleProvider" type="umbraco.providers.members.UmbracoRoleProvider" />
      </providers>
    </roleManager>
    <!-- Sitemap provider-->
    <siteMap defaultProvider="UmbracoSiteMapProvider" enabled="true">
      <providers>
        <clear />
        <add name="UmbracoSiteMapProvider" type="umbraco.presentation.nodeFactory.UmbracoSiteMapProvider" defaultDescriptionAlias="description" securityTrimmingEnabled="true" />
      </providers>
    </siteMap>
  </system.web>
  <!-- ASPNETAJAX -->
  <system.web.extensions>
    <scripting>
      <scriptResourceHandler enableCompression="true" enableCaching="true" />
    </scripting>
  </system.web.extensions>
  <system.webServer>
    <validation validateIntegratedModeConfiguration="false" />
    <modules runAllManagedModulesForAllRequests="true">
      <!--<add name="PerformanceModule" type="CursusIndex.performance.PerformanceModule"/>-->
      <remove name="ScriptModule" />
      <remove name="UrlRewriteModule" />
      <remove name="umbracoRequestModule" />
      <remove name="viewstateMoverModule" />
      <remove name="umbracoBaseRequestModule" />
      <remove name="ClientDependencyModule" />
      <!-- Needed for login/membership to work on homepage (as per http://stackoverflow.com/questions/218057/httpcontext-current-session-is-null-when-routing-requests) -->
      <remove name="FormsAuthentication" />
      <add name="UrlRewriteModule" type="UrlRewritingNet.Web.UrlRewriteModule, UrlRewritingNet.UrlRewriter" />
      <add name="umbracoRequestModule" type="umbraco.presentation.requestModule" />
      <add name="viewstateMoverModule" type="umbraco.presentation.viewstateMoverModule" />
      <add name="umbracoBaseRequestModule" type="umbraco.presentation.umbracobase.requestModule" />
      <add name="ScriptModule" preCondition="managedHandler" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <add name="ClientDependencyModule" type="ClientDependency.Core.Module.ClientDependencyModule, ClientDependency.Core" />
      <!-- Needed for login/membership to work on homepage (as per http://stackoverflow.com/questions/218057/httpcontext-current-session-is-null-when-routing-requests) -->
      <add name="FormsAuthentication" type="System.Web.Security.FormsAuthenticationModule" />
    </modules>
    <handlers accessPolicy="Read, Write, Script, Execute">
      <remove name="WebServiceHandlerFactory-Integrated" />
      <remove name="ScriptHandlerFactory" />
      <remove name="ScriptHandlerFactoryAppServices" />
      <remove name="ScriptResource" />
      <remove name="Channels" />
      <remove name="Channels_Word" />
      <remove name="ClientDependency" />
      <remove name="SpellChecker" />
      <add name="ScriptHandlerFactory" verb="*" path="*.asmx" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <add name="ScriptHandlerFactoryAppServices" verb="*" path="*_AppService.axd" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <add name="ScriptResource" verb="GET,HEAD" path="ScriptResource.axd" preCondition="integratedMode" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
      <add verb="*" name="Channels" preCondition="integratedMode" path="umbraco/channels.aspx" type="umbraco.presentation.channels.api, umbraco" />
      <add verb="*" name="Channels_Word" preCondition="integratedMode" path="umbraco/channels/word.aspx" type="umbraco.presentation.channels.wordApi, umbraco" />
      <add verb="*" name="ClientDependency" preCondition="integratedMode" path="DependencyHandler.axd" type="ClientDependency.Core.CompositeFiles.CompositeDependencyHandler, ClientDependency.Core " />
      <add verb="GET,HEAD,POST" preCondition="integratedMode" name="SpellChecker" path="GoogleSpellChecker.ashx" type="umbraco.presentation.umbraco_client.tinymce3.plugins.spellchecker.GoogleSpellChecker,umbraco" />
    </handlers>
    <!-- Adobe AIR mime type -->
    
    <staticContent>
      <mimeMap fileExtension=".air" mimeType="application/vnd.adobe.air-application-installer-package+zip" />
    </staticContent>
        <rewrite>
            <rules>
              <rule name="Redirect to www" patternSyntax="Wildcard" stopProcessing="false">
                <match url="*" />
                <conditions>
                  <add input="{HTTP_HOST}" pattern="tekstenuitleg.net" />
                </conditions>
                <action type="Redirect" url="http://www.tekstenuitleg.net/{R:0}" />
              </rule>
              <rule name="Redirect /en to subdomain 3" stopProcessing="false">
                <match url="^en/(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://en.tekstenuitleg.net/{R:1}" />
              </rule>
              <rule name="Redirect /en to subdomain 4" stopProcessing="false">
                <match url="^en$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://en.tekstenuitleg.net/" />
              </rule>

              <!-- page rewrite rules -->
              <rule name="Redirect old articles1" stopProcessing="true">
                <match url="^articles/hardware/optical-wireless-mice(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://en.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles2" stopProcessing="true">
                <match url="^articles/networking/remote-access-computer(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://en.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles3" stopProcessing="true">
                <match url="^articles/networking/router-buying-tips(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://en.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles4" stopProcessing="true">
                <match url="^articles/software/outlook-tutorial(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://en.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles5" stopProcessing="true">
                <match url="^artikelen/internet/bots(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles6" stopProcessing="true">
                <match url="^artikelen/internet/content-is-king(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles7" stopProcessing="true">
                <match url="^artikelen/internet/seo-indeling-linkstructuur(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles8" stopProcessing="true">
                <match url="^artikelen/internet/seo-pagerank(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles9" stopProcessing="true">
                <match url="^artikelen/internet/seo-trefwoorden-concurrentie(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles10" stopProcessing="true">
                <match url="^artikelen/internet/google_g1(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles11" stopProcessing="true">
                <match url="^artikelen/netwerken/programmas-internet-delen(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles12" stopProcessing="true">
                <match url="^artikelen/internet/seo-paginafactoren(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles13" stopProcessing="true">
                <match url="^artikelen/internet/zoekmachine-optimalisatie(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles14" stopProcessing="true">
                <match url="^artikelen/internet/cursus-google(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>

              <rule name="Redirect old articles15" stopProcessing="true">
                <match url="^artikelen/hardware/data-recovery(.*)$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net" />
              </rule>
			  
			  <rule name="Redirect old database url" stopProcessing="true">
                <match url="^artikelen/cursus_database_ontwerpen/1$" ignoreCase="false" />
                <action type="Redirect" redirectType="Permanent" url="http://www.tekstenuitleg.net/artikelen/software/cursus-database-ontwerpen/introductie.html" />
              </rule>
			  

              
              

            </rules>
        </rewrite>

    <httpErrors>
      <remove statusCode="404" subStatusCode="-1" />
      <error statusCode="404" prefixLanguageFilePath="" path="/404" responseMode="ExecuteURL" />
    </httpErrors>
  </system.webServer>
  <system.codedom>
    <compilers>
      <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CSharp.CSharpCodeProvider,System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" warningLevel="4">
        <providerOption name="CompilerVersion" value="v4.0" />
        <providerOption name="WarnAsError" value="false" />
      </compiler>
    </compilers>
  </system.codedom>
  <runtime>
    <!-- Old asp.net ajax assembly bindings -->
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Extensions" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="4.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Extensions.Design" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="4.0.0.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <!-- Added in Umbraco 4.6.2 -->
  <system.web.webPages.razor>
    <host factoryType="umbraco.MacroEngines.RazorUmbracoFactory, umbraco.MacroEngines" />
    <pages pageBaseType="umbraco.MacroEngines.DynamicNodeContext">
      <namespaces>
        <add namespace="Microsoft.Web.Helpers" />
        <add namespace="umbraco" />
        <add namespace="Examine" />
      </namespaces>
    </pages>
  </system.web.webPages.razor>
  <!-- End of added in Umbraco 4.6.2 -->
</configuration>