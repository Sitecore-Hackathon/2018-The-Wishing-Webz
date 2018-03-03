# Package
Please include a .zip or .update file which will allow the module to be installed into a clean version of Sitecore.

If there are any post-install steps required then please include it in the documentation. Remember, packages can include files and DLLs using the *Files dynamically* or *Files statically* option in the **Package Designer**.

# How To Install XConsent Module
- Download XConsent-1.0.0.zip
- Extract to Location of Your Choice
    - '[Location of Your Choice]/XConsent-1.0.0-installer.zip'
    - '[Location of Your Choice]/GDT.TrackingConsent.Models, 1.0.json'
- Install 'XConsent-1.0.0-installer.zip' via Sitecore Package Installer
- Paste 'GDT.TrackingConsent.Models, 1.0.json' in below locations:
    - '[Sitecore Install Location]/<sitecore install name>xconnect\App_data\Models'
    - '[Sitecore Install Location]/<sitecore install name>xconnect\App_data\jobs\continuous\IndexWorker\App_data\Models'
- **Success!**    
