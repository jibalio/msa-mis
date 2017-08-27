# MSA-MIS
An information system for Makabayan Security Agency written in C# &#x1F499;&#x1F499;&#x1F499;

## Setting-up
### References
MSA-MIS requires:
- [Microsoft.Office.Interop.Excel 15.0.4795.1000](Install-Package Microsoft.Office.Interop.Excel -Version 15.0.4795.1000)
- [MySql.Data 6.9.9](https://www.nuget.org/packages/MySql.Data/6.9.9)
- [MySqlBackup.NET 2.0.9.2](https://www.nuget.org/packages/MySqlBackup.NET/2.0.9.2) 
- [iTextSharp 5.5.11](https://www.nuget.org/packages/iTextSharp/5.5.11)
- [BCrypt.Net-Next 2.1.1](https://www.nuget.org/packages/BCrypt.Net-Next/2.1.1)
- [ini-parser 2.5.2.0](https://github.com/rickyah/ini-parser)

**How to install (Package Manager Console)**
```
PM > Get-Project -All | Install-Package MySql.Data -version 6.9.9
PM > Get-Project -ryldb.sqltools | Install-Package MySqlBackup.NET -Version 2.0.9.2
PM> Get-Project ryldb.sqltools | Install-Package Microsoft.Office.Interop.Excel
PM> Get-Project ryldb.sqltools | Install-Package BCrypt.Net-Next -Version 2.1.1
PM> Get-Project ryldb.sqltools | Install-Package iTextSharp -Version 5.5.11 
PM> Get-Project ryldb.sqltools | Install-Package ini-parser
```

### Database 
Get SQL Dump [here](https://github.com/lerycibalio/msa-mis/tree/master/sql).

**On export, enable:** 
- Dump Stored Procedures and Functions
- Dump Triggers
- Include Create Schema *(MySql Workbench 6.3+ only)*

## About
### Modules
* Guard and Client Management Module
* Duty Scheduling Module
* Payroll Module
