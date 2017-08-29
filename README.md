# Serialization helpers for System.Collections.Immutable

Collections in [System.Collections.Immutable](https://www.nuget.org/packages/System.Collections.Immutable) are not serializable. This library provides serializable wrappers for the collections, which allow  using them as-is, while efficiently serializing and deserializing them (when possible, using a `Builder`).

[![NuGet](https://img.shields.io/nuget/v/ImmutableCollections.Serialization.svg)](https://www.nuget.org/packages/ImmutableCollections.Serialization/)

## Usage

```csharp

[DataContract]
public class ImmutableData
{
	[DataMember]
	private readonly ImmutableListSerializable<int> _list = new ImmutableListSerializable<int>();
	
	public ImmutableList<int> List
	{
		get => _list.Value;
		private set => _list.Value = value;
	}
	
	public ImmutableData WithList(ImmutableList<int> list)
	{
		return new ImmutableData { List = list };
	}
}

```
