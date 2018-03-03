# Documentation

## Summary

**Category:** XConnect

With GDPR fast approaching, the ability to consent into tracking and PII data is very important.  We wanted to extend XConnect with our Module "XConsent" to allow for users to consent to being tracked in XConnect.

XConsent installs a library (bin\GDT.TrackingConsent.dll) and a base template (/sitecore/templates/XConsent/Base_XConsent) that should be inherited by the template associated to 'rootPath' in 'site' node

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- Sitecore 9.0.1 
- XConnect

## How To Install XConsent Module
- Download [XConsent-1.0.0.zip](#link-to-package)
- Extract to Location of Your Choice
    - '[Location of Your Choice]/XConsent-1.0.0-installer.zip'
    - '[Location of Your Choice]/GDT.TrackingConsent.Models, 1.0.json'
- Install 'XConsent-1.0.0-installer.zip' via Sitecore Package Installer
- Paste 'GDT.TrackingConsent.Models, 1.0.json' in below locations:
    - '[Sitecore Install Location]/<sitecore install name>xconnect\App_data\Models'
    - '[Sitecore Install Location]/<sitecore install name>xconnect\App_data\jobs\continuous\IndexWorker\App_data\Models'
- **Success!**    


## Configuration and Usage

Inherit Base Template on your rootPath item
```xml
<site name="website" enableTracking="true" virtualFolder="/" physicalFolder="/" rootPath="/sitecore/content" startItem="/home" language="en" database="web" domain="extranet" allowDebug="true" cacheHtml="true" htmlCacheSize="50MB" registryCacheSize="0" viewStateCacheSize="0" xslCacheSize="25MB" filteredItemsCacheSize="10MB" enablePreview="true" enableWebEdit="true" enableDebugger="true" disableClientData="false" cacheRenderingParameters="true" renderingParametersCacheSize="10MB" enableItemLanguageFallback="false" enableFieldLanguageFallback="false" role:require="Standalone or Reporting or ContentManagement or ContentDelivery" />
```
In above example, /sitecore/content would need to inherit Base_XConsent

On /sitecore/content, Check XConsent Enabled, and Link XConsent Policy to your Privacy Policy

## Video
[View XConsent in Action](https://www.youtube.com/watch?v=EpNhxW4pNKk)

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
