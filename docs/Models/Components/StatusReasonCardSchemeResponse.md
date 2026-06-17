# StatusReasonCardSchemeResponse

## Example Usage

```csharp
using Mollie.Models.Components;

var value = StatusReasonCardSchemeResponse.ApprovedOrCompletedSuccessfully;

// Open enum: use .Of() to create instances from custom string values
var custom = StatusReasonCardSchemeResponse.Of("custom_value");
```


## Values

| Name                                             | Value                                            |
| ------------------------------------------------ | ------------------------------------------------ |
| `ApprovedOrCompletedSuccessfully`                | approved_or_completed_successfully               |
| `ReferToCardIssuer`                              | refer_to_card_issuer                             |
| `InvalidMerchant`                                | invalid_merchant                                 |
| `CaptureCard`                                    | capture_card                                     |
| `DoNotHonor`                                     | do_not_honor                                     |
| `Error`                                          | error                                            |
| `PartialApproval`                                | partial_approval                                 |
| `InvalidTransaction`                             | invalid_transaction                              |
| `InvalidAmount`                                  | invalid_amount                                   |
| `InvalidIssuer`                                  | invalid_issuer                                   |
| `LostCard`                                       | lost_card                                        |
| `StolenCard`                                     | stolen_card                                      |
| `InsufficientFunds`                              | insufficient_funds                               |
| `ExpiredCard`                                    | expired_card                                     |
| `InvalidPin`                                     | invalid_pin                                      |
| `TransactionNotPermittedToCardholder`            | transaction_not_permitted_to_cardholder          |
| `TransactionNotAllowedAtTerminal`                | transaction_not_allowed_at_terminal              |
| `ExceedsWithdrawalAmountLimit`                   | exceeds_withdrawal_amount_limit                  |
| `RestrictedCard`                                 | restricted_card                                  |
| `SecurityViolation`                              | security_violation                               |
| `ExceedsWithdrawalCountLimit`                    | exceeds_withdrawal_count_limit                   |
| `AllowableNumberOfPinTriesExceeded`              | allowable_number_of_pin_tries_exceeded           |
| `NoReasonToDecline`                              | no_reason_to_decline                             |
| `CannotVerifyPin`                                | cannot_verify_pin                                |
| `IssuerUnavailable`                              | issuer_unavailable                               |
| `UnableToRouteTransaction`                       | unable_to_route_transaction                      |
| `DuplicateTransaction`                           | duplicate_transaction                            |
| `SystemMalfunction`                              | system_malfunction                               |
| `HonorWithId`                                    | honor_with_id                                    |
| `InvalidCardNumber`                              | invalid_card_number                              |
| `FormatError`                                    | format_error                                     |
| `ContactCardIssuer`                              | contact_card_issuer                              |
| `PinNotChanged`                                  | pin_not_changed                                  |
| `InvalidNonexistentToAccountSpecified`           | invalid_nonexistent_to_account_specified         |
| `InvalidNonexistentFromAccountSpecified`         | invalid_nonexistent_from_account_specified       |
| `InvalidNonexistentAccountSpecified`             | invalid_nonexistent_account_specified            |
| `LifecycleRelated`                               | lifecycle_related                                |
| `DomesticDebitTransactionNotAllowed`             | domestic_debit_transaction_not_allowed           |
| `PolicyRelated`                                  | policy_related                                   |
| `FraudSecurityRelated`                           | fraud_security_related                           |
| `InvalidAuthorizationLifeCycle`                  | invalid_authorization_life_cycle                 |
| `PurchaseAmountOnlyNoCashBackAllowed`            | purchase_amount_only_no_cash_back_allowed        |
| `CryptographicFailure`                           | cryptographic_failure                            |
| `UnacceptablePin`                                | unacceptable_pin                                 |
| `ReferToCardIssuerSpecialCondition`              | refer_to_card_issuer_special_condition           |
| `PickUpCardSpecialCondition`                     | pick_up_card_special_condition                   |
| `VipApproval`                                    | vip_approval                                     |
| `InvalidAccountNumber`                           | invalid_account_number                           |
| `ReEnterTransaction`                             | re_enter_transaction                             |
| `NoActionTaken`                                  | no_action_taken                                  |
| `UnableToLocateRecord`                           | unable_to_locate_record                          |
| `FileTemporarilyUnavailable`                     | file_temporarily_unavailable                     |
| `NoCreditAccount`                                | no_credit_account                                |
| `ClosedAccount`                                  | closed_account                                   |
| `NoCheckingAccount`                              | no_checking_account                              |
| `NoSavingsAccount`                               | no_savings_account                               |
| `SuspectedFraud`                                 | suspected_fraud                                  |
| `TransactionDoesNotFulfillAmlRequirement`        | transaction_does_not_fulfill_aml_requirement     |
| `PinDataRequired`                                | pin_data_required                                |
| `UnableToLocatePreviousMessage`                  | unable_to_locate_previous_message                |
| `PreviousMessageLocatedInconsistentData`         | previous_message_located_inconsistent_data       |
| `BlockedFirstUsed`                               | blocked_first_used                               |
| `TransactionReversed`                            | transaction_reversed                             |
| `CreditIssuerUnavailable`                        | credit_issuer_unavailable                        |
| `PinCryptographicErrorFound`                     | pin_cryptographic_error_found                    |
| `NegativeOnlineCamResult`                        | negative_online_cam_result                       |
| `ViolationOfLaw`                                 | violation_of_law                                 |
| `ForceStip`                                      | force_stip                                       |
| `CashServiceNotAvailable`                        | cash_service_not_available                       |
| `CashbackRequestExceedsIssuerLimit`              | cashback_request_exceeds_issuer_limit            |
| `DeclineForCvv2Failure`                          | decline_for_cvv2_failure                         |
| `TransactionAmountExceedsPreAuthorizedAmount`    | transaction_amount_exceeds_pre_authorized_amount |
| `InvalidBillerInformation`                       | invalid_biller_information                       |
| `PinChangeUnblockRequestDeclined`                | pin_change_unblock_request_declined              |
| `UnsafePin`                                      | unsafe_pin                                       |
| `CardAuthenticationFailed`                       | card_authentication_failed                       |
| `StopPaymentOrder`                               | stop_payment_order                               |
| `RevocationOfAuthorization`                      | revocation_of_authorization                      |
| `RevocationOfAllAuthorizations`                  | revocation_of_all_authorizations                 |
| `ForwardToIssuerXa`                              | forward_to_issuer_xa                             |
| `ForwardToIssuerXd`                              | forward_to_issuer_xd                             |
| `UnableToGoOnline`                               | unable_to_go_online                              |
| `AdditionalCustomerAuthenticationRequired`       | additional_customer_authentication_required      |