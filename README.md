# DnD Trading Website

An ASP.NET Web Forms application developed for a stationery distribution business as part of a University of KwaZulu-Natal team project in 2025.

The website includes customer-facing product and order pages alongside client and supplier management screens. It complements the [DnD Trading desktop application](https://github.com/DarianRobert/DnD-Trading).

## Technology

| Component | Technology |
| --- | --- |
| Web framework | ASP.NET Web Forms with C# code-behind |
| Runtime target | .NET Framework 4.7.2 |
| Database and access | SQL Server, ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) |
| Frontend | HTML, CSS, JavaScript, Bootstrap, jQuery |
| Local development | Visual Studio, IIS Express, NuGet |

## Features represented in the source

- Product browsing and checkout pages.
- Login, client details, and client order pages.
- Supplier and supplier product pages.
- Order and report pages.
- Contact and order email functionality.

## My contribution

I led the wider DnD Trading project team, coordinated development goals and timelines, and contributed to frontend and backend development across the project. This repository contains the team's website component.

## Repository layout

The solution, ASP.NET pages and C# source are available directly in the repository root. This portfolio fork preserves the original team commit history.

| Path | Purpose |
| --- | --- |
| `DNDWebsite.sln`, `DNDWebsite.csproj` | Visual Studio solution and web application project |
| `Default.aspx`, `Products.aspx` | Landing and product pages |
| `Login.aspx`, `Clients.aspx`, `EditClient.aspx` | Login and client pages |
| `Checkout.aspx`, `Order.aspx`, `ClientOrders.aspx` | Checkout and order pages |
| `Supplier.aspx`, `SupplierProducts.aspx` | Supplier pages |
| `Report.aspx`, `Contact.aspx` | Reports and contact pages |
| `Site.Master` and `.aspx.cs` files | Shared layout and C# page logic |
| `Web.config` | Web application and database configuration |
| `packages.config` | NuGet dependency versions |

## Development setup

1. Install Visual Studio with the **ASP.NET and web development** workload and the **.NET Framework 4.7.2 targeting pack** on Windows.
2. Clone this repository and open `DNDWebsite.sln`:

   ```bash
   git clone https://github.com/DarianRobert/DnD-Trading-Website.git
   cd DnD-Trading-Website
   ```
3. Restore the packages listed in `packages.config` using Visual Studio's NuGet package restore.
4. Prepare an isolated SQL Server development database and configure `DNDConnectionString` in your local `Web.config` for it. The page code expects the original application's database tables and relationships.
5. Configure a test email service before exercising contact or order email actions.
6. Select IIS Express and start the application from Visual Studio.

## Current limitations

- A database provisioning script and sample dataset have not yet been packaged.
- Database and email configuration are environment-specific; review the configuration files and page code before running against your own test services.
- A clean Windows/IIS Express run and the application workflows have not yet been verified on a fresh development environment.

## Team provenance

This is Darian Robert's portfolio fork of the [original team repository](https://github.com/ArjunRamphal/DNDWebsite). The website and its history include work from multiple team members.

## Related work

- [DnD Trading desktop application](https://github.com/DarianRobert/DnD-Trading)
- [My project portfolio](https://darianrobert.github.io/)

