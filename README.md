# MSA-MIS
An information system for Makabayan Security Agency written in C# &#x1F499;&#x1F499;&#x1F499;



## Installation
### Prerequisite Packages
MSA-MIS requires [MySql.Data 6.9.9](https://www.nuget.org/packages/MySql.Data/6.9.9) and [MySqlBackup.NET 2.0.9.2](https://www.nuget.org/packages/MySqlBackup.NET/2.0.9.2) to run. **Note: These packages should install automatically** *(Internet Connection Required)*. If automatic installation fails, these packages can be installed using the NuGet Package Manager.

Go to `Tools > NuGet Package Manager > Package Manager Console`
```
PM > Get-Project -All | Install-Package MySql.Data -version 6.9.9
PM > Get-Project -ryldb.sqltools | Install-Package MySqlBackup.NET -Version 2.0.9.2
PM> Get-Project ryldb.sqltools | Install-Package Microsoft.Office.Interop.Excel
PM> Get-Project ryldb.sqltools | Install-Package BCrypt.Net-Next -Version 2.1.1
```

### Database 
**The program automatically imports the database**. If this fails, download the SQL Dump [here](https://github.com/lerycibalio/msa-mis/tree/master/sql) and manually import to databases `msadb` and `msadbarchive`.

### Software
~~**Backend:** Export the database dump **using MySQL Workbench 6.3.8+ only**. Using older versions will cause MSA-MIS's auto-database-import component `(AutoLoader.cs)` to fail. *Ayaw gamita ang sql workbench sa F610 kay mabungkag ang AutoLoader.cs, kara-an kaayo*.~~
Nvm ok na.

**Important (MySql Workbench 6.3+ only)**: Turn on  'Include Create Schema' in export settings. 

## About
### Modules
* Guard and Client Management Module
* Duty Scheduling Module
* Payroll Module


<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>
<br>

**U shouldn't be in here, go scroll back up.**

## Benchmark: Payroll object serialization

```
Manual Calculation Method: 0.046613  		46.613ms
Done
Manual Calculation Method: 0.0135579		13.5579ms
Exception thrown: 'System.NullReferenceException' in MSAMISUserInterface.exe
Done
Manual Calculation Method: 0.0157274		15.7274ms
Done
Manual Calculation Method: 0.0128501		12.8501


Object Deserialization Method: 0.0044557	4.4557ms  (10.4614314249164x faster)
Exception thrown: 'System.NullReferenceException' in MSAMISUserInterface.exe
Done
Object Deserialization Method: 0.0029781	2.9781ms (4.552533494509922x faster)
Done
Object Deserialization Method: 0.0035875	3.5875ms 
Done
Object Deserialization Method: 0.0041089	4.1089ms
```



**Conclusion:** Use object serialization in (uneditable data).

