# Debtor

The debtor (sender) of the transfer, including their name and account details.


## Fields

| Field                                                                         | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `FullName`                                                                    | *string*                                                                      | :heavy_check_mark:                                                            | The full name of the account holder.                                          | Jan Jansen                                                                    |
| `Account`                                                                     | [TransferResponseAccount](../../Models/Components/TransferResponseAccount.md) | :heavy_check_mark:                                                            | The bank account details of the party.                                        |                                                                               |