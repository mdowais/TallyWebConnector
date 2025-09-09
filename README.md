# TallyWebConnector

A .NET 8 Web API that provides REST endpoints for interacting with Tally ERP 9 through the TallyConnector library.

## Features

This API provides endpoints for all major Tally ERP modules:

### Core Operations
- **Connection Check**: Test connectivity to Tally ERP
- **System Info**: Get Tally system information

### Business Modules
- **Vouchers**: CRUD operations for vouchers and voucher types
- **Ledgers**: Ledger management and balance queries
- **Stock Items**: Stock item operations and balance tracking
- **Stock Groups**: Stock group management
- **Companies**: Company information and switching
- **Groups**: Account group management
- **Godowns**: Warehouse/location management
- **Units**: Unit of measurement operations

### Compliance & Reports
- **GST**: GST reports, returns, GSTR1, GSTR3B
- **TDS**: TDS reports, returns, quarterly filings
- **Balance Sheet**: Balance sheet reports
- **Profit & Loss**: P&L statements
- **Trial Balance**: Trial balance reports
- **Cash Flow**: Cash flow statements

### Audit & Tracking
- **Edit Log**: Change tracking and audit trails
- **User Activity**: User activity logs

## Quick Start

1. **Prerequisites**
   - .NET 8 SDK
   - Tally ERP 9 running with Gateway enabled (default port 9000)

2. **Configuration**
   Update `appsettings.json` with your Tally connection details:
   ```json
   {
     "TallyHost": "http://localhost",
     "TallyPort": "9000"
   }
   ```

3. **Run the API**
   ```bash
   dotnet run
   ```

4. **Access Swagger UI**
   Open `https://localhost:7155/swagger` (Development) or `http://localhost:5169/swagger`

## API Endpoints

### Core
- `GET /api/core/check` - Test Tally connectivity
- `GET /api/core/info` - Get Tally system info

### Vouchers
- `GET /api/vouchers` - Get all vouchers
- `GET /api/vouchers/{id}` - Get voucher by ID
- `GET /api/voucher-types` - Get all voucher types

### Ledgers
- `GET /api/ledgers` - Get all ledgers
- `GET /api/ledgers/{id}` - Get ledger by ID
- `GET /api/ledgers/{id}/balance` - Get ledger balance

### Stock Items
- `GET /api/stock-items` - Get all stock items
- `GET /api/stock-items/{id}` - Get stock item by ID
- `GET /api/stock-items/{id}/balance` - Get stock item balance

### Stock Groups
- `GET /api/stock-groups` - Get all stock groups
- `GET /api/stock-groups/{id}` - Get stock group by ID

### Companies
- `GET /api/companies` - Get all companies
- `GET /api/companies/{id}` - Get company by ID
- `GET /api/companies/current` - Get current active company

### Groups
- `GET /api/groups` - Get all groups
- `GET /api/groups/{id}` - Get group by ID

### Godowns
- `GET /api/godowns` - Get all godowns
- `GET /api/godowns/{id}` - Get godown by ID

### Units
- `GET /api/units` - Get all units
- `GET /api/units/{id}` - Get unit by ID

### GST
- `GET /api/gst/reports` - Get GST reports
- `GET /api/gst/returns` - Get GST returns
- `GET /api/gst/gstr1?fromDate={date}&toDate={date}` - Get GSTR1 report
- `GET /api/gst/gstr3b?fromDate={date}&toDate={date}` - Get GSTR3B report

### TDS
- `GET /api/tds/reports` - Get TDS reports
- `GET /api/tds/returns` - Get TDS returns
- `GET /api/tds/quarterly?quarter={int}&year={int}` - Get TDS quarterly report

### Reports
- `GET /api/reports/balance-sheet?asOnDate={date}` - Get Balance Sheet
- `GET /api/reports/profit-loss?fromDate={date}&toDate={date}` - Get P&L
- `GET /api/reports/trial-balance?asOnDate={date}` - Get Trial Balance
- `GET /api/reports/cash-flow?fromDate={date}&toDate={date}` - Get Cash Flow

### Edit Log
- `GET /api/edit-log?fromDate={date}&toDate={date}` - Get edit log
- `GET /api/edit-log/{entityType}/{entityId}` - Get edit log for specific entity
- `GET /api/edit-log/user-activity?userId={string}` - Get user activity

## Architecture

This API follows minimal API pattern with:
- **Business Logic Services**: Each Tally module has its own service class
- **Dependency Injection**: All services are registered in DI container
- **Error Handling**: Comprehensive try-catch blocks with graceful error responses
- **Swagger Integration**: Full API documentation with Swagger/OpenAPI

## Dependencies

- **TallyConnector 2.2.0**: Core library for Tally ERP integration
- **Swashbuckle.AspNetCore**: API documentation and testing UI

## Docker Support

The project includes Docker support. Build and run with:

```bash
docker build -t tallywebconnector .
docker run -p 8080:80 tallywebconnector
```

## Development

To extend the API:

1. Create service classes in the `Services` folder
2. Register services in `Program.cs`
3. Add endpoint mappings in `Program.cs`
4. Follow the existing patterns for error handling and response formatting