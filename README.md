# CurrencyConversionAPI

**CurrencyConversionAPI** is a web api project to convert usd to inr and eur to usd exchange rates

This project is built in **ASP.NET  (.NET Framework 4.7.2)**


## 📒 Table of Contents 

- [System Requirements](#-system-requirements)
- [Setup](#-setup)
- [Run Project](#-run-project)
- [Usage](#-usage)
- [Build](#-build)

## ⚙ System Requirements

* IDE Framework - **Visual Studio 2019 or higher**
* OS - **Windows 8 or higher**
* **IIS** should be installed.
---
## 🛠 Setup

1. Download the project from this repository.
2. Right-click on downloaded zip file. Click Properties. Check the checkbox for **Unblock**. Click Apply.
	> You can skip this step if you are cloning the repository.
	
3. Open **CurrencyConversionAPI.sln** file via Visual Studio.
4. Right-click on **CurrencyConversionAPI** and select **Set as Startup Project**.

---
## ⌛ Run Project

* Right-click on **CurrencyConversionAPI** project. Click _**Set as Startup Project**_.
* Run the project by pressing **F5** in the keyboard.
* Use the localhost url from browser and append the following - api/home/inventory
* URL https://localhost:44366/eur/100/usd?access_key=135a1eb922ae3aa21eefa5be17f510ec&amt=1&from_curr=eur&to_curr=usd    **GET METHOD FOR USD TO INR**
* URL https://localhost:44366/eur/100/usd?access_key=135a1eb922ae3aa21eefa5be17f510ec&amt=1&from_curr=eur&to_curr=usd     **GET METHOD FOR EUR TO USD**
* key = **access_key** , value = **135a1eb922ae3aa21eefa5be17f510ec**

---
## ✔ Usage

* USD To INR Currency Conversion
* EUR To USD Currency Conversion
---
## 🌐 Build

* In the Build Menu, change Configuration Manager from Debug to **Release**.
* Right-click on **CurrencyConversionAPI** project. Select **Publish**.
* Select **Folder** from list of Hosting options. Click **Next**.
* Choose a publishing directory. 
* Click **Finish**.
---




