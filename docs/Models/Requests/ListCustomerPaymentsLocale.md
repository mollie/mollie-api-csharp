# ListCustomerPaymentsLocale

Allows you to preset the language to be used in the hosted payment pages shown to the customer. Setting a locale
is highly recommended and will greatly improve your conversion rate. When this parameter is omitted the browser
language will be used instead if supported by the payment method. You can provide any `xx_XX` format ISO 15897
locale, but our hosted payment pages currently only support the specified languages.

For bank transfer payments specifically, the locale will determine the target bank account the customer has to
transfer the money to. We have dedicated bank accounts for Belgium, Germany, and The Netherlands. Having the
customer use a local bank account greatly increases the conversion and speed of payment.


## Values

| Name   | Value  |
| ------ | ------ |
| `EnUS` | en_US  |
| `EnGB` | en_GB  |
| `Nlnl` | nl_NL  |
| `NlBE` | nl_BE  |
| `Dede` | de_DE  |
| `DeAT` | de_AT  |
| `DeCH` | de_CH  |
| `Frfr` | fr_FR  |
| `FrBE` | fr_BE  |
| `Eses` | es_ES  |
| `CaES` | ca_ES  |
| `Ptpt` | pt_PT  |
| `Itit` | it_IT  |
| `NbNO` | nb_NO  |
| `SvSE` | sv_SE  |
| `Fifi` | fi_FI  |
| `DaDK` | da_DK  |
| `Isis` | is_IS  |
| `Huhu` | hu_HU  |
| `Plpl` | pl_PL  |
| `Lvlv` | lv_LV  |
| `Ltlt` | lt_LT  |