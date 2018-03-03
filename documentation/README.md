# Documentation

The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

Examples of things to include are the following.

## Summary

**Category:** XConnect

With GDPR fast approaching, the ability to consent into tracking and PII data is very important.  We wanted to extend XConnect with our Module "XConsent" to allow for users to consent to being tracked in XConnect.

XConsent installs a library (bin\GDT.TrackingConsent.dll) and a base template (/sitecore/templates/XConsent/Base_XConsent) that should be inherited by the template associated to 'rootPath' in 'site' node

## Pre-requisites

Does your module rely on other Sitecore modules or frameworks?

- Sitecore 9.0.1 
- XConnect

## Installation
1. Use the Sitecore Installation wizard to install the [package](#link-to-package)

## Configuration

Inherit Base Template on your rootPath item
```xml
<site name="website" enableTracking="true" virtualFolder="/" physicalFolder="/" rootPath="/sitecore/content" startItem="/home" language="en" database="web" domain="extranet" allowDebug="true" cacheHtml="true" htmlCacheSize="50MB" registryCacheSize="0" viewStateCacheSize="0" xslCacheSize="25MB" filteredItemsCacheSize="10MB" enablePreview="true" enableWebEdit="true" enableDebugger="true" disableClientData="false" cacheRenderingParameters="true" renderingParametersCacheSize="10MB" enableItemLanguageFallback="false" enableFieldLanguageFallback="false" role:require="Standalone or Reporting or ContentManagement or ContentDelivery" />
```
In above example, /sitecore/content would need to inherit Base_XConsent

On /sitecore/content, Check XConsent Enabled, and Link XConsent Policy to your Privacy Policy

## Usage

Provide documentation  about your module, how do the users use your module, where are things located, what do icons mean, are there any secret shortcuts etc.

Please include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://placeimg.com/480/240/any "Random")

## Video
:D
Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
