# KamenickyEncoding
Encoding of 895 (Kamenicky) is not supported in .NET FW. 
This project adding support for Encoding 895 (Kamenicky).


## What is Kamenicky (895) encoding
Encoding was created by brothers Kamenicky and was popular in 90ties.  
Encoding was based on code page 437 where Czech and Slovak characters were replaced by characters from point 128 to 173.  
More info [here](https://en.wikipedia.org/wiki/Kamenick%C3%BD_encoding).

## Available as NuGet Package

```
PM> Install-Package KamenickyEncoding
```

## Example of Use

* How to encodes a set of characters into a sequence of bytes to Kamenicky 895.
```csharp
var encoding = new KamenickyEncoding.Kamenicky895Encoding();
var bytes = encoding.GetBytes("text");
```

* How to decodes from Kamenicky (895) a sequence of bytes into a set of characters.
```csharp
var encoding = new KamenickyEncoding.Kamenicky895Encoding();
var bytes = encoding.GetChars(bytes);
```

* How to decodes from Kamenicky (895) a sequence of bytes into a string.
```csharp
var encoding = new KamenickyEncoding.Kamenicky895Encoding();
var bytes = encoding.GetString(bytes);
```

* How register custom Kamenicky895RegisterProvider.
```csharp
System.Text.Encoding.RegisterProvider(new KamenickyEncoding.Kamenicky895EncodingProvider());
```

* How to get encoding by code page (use 895 as code page) for registered provider.
```csharp
System.Text.Encoding.RegisterProvider(new KamenickyEncoding.Kamenicky895EncodingProvider());
var encoding = Encoding.GetEncoding(895);
```

* How to get encoding by name (use kamenicky895 as name) for registered provider.
```csharp
System.Text.Encoding.RegisterProvider(new KamenickyEncoding.Kamenicky895EncodingProvider());
var encoding = Encoding.GetEncoding("kamenicky895");
```