# ListPaymentsMetadata

Provide any data you like, for example a string or a JSON object. We will save the data alongside the entity. Whenever
you fetch the entity with our API, we will also include the metadata. You can use up to approximately 1kB.


## Supported Types

### Str

```csharp
ListPaymentsMetadata.CreateStr(/* values here */);
```

### MapOfAny

```csharp
ListPaymentsMetadata.CreateMapOfAny(/* values here */);
```

### ArrayOfStr

```csharp
ListPaymentsMetadata.CreateArrayOfStr(/* values here */);
```
