# TransferParty

A party involved in the transfer, representing either the debtor (sender) or creditor (recipient).
Contains the party's name and account details.


## Fields

| Field                                                                   | Type                                                                    | Required                                                                | Description                                                             | Example                                                                 |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `FullName`                                                              | *string*                                                                | :heavy_check_mark:                                                      | The full name of the account holder.                                    | Jan Jansen                                                              |
| `Account`                                                               | [TransferPartyAccount](../../Models/Components/TransferPartyAccount.md) | :heavy_check_mark:                                                      | The bank account details of the party.                                  |                                                                         |