using System.Text;

namespace AssetRipper.Yaml.Extensions
{
	public static class YamlArrayExtensions
	{
		public static YamlNode ExportYaml(this byte[] _this)
		{
			// Ensure sufficient space for the string
			long length = (long)_this.Length * 2;
			if (length > int.MaxValue)
			{
				throw new ArgumentException($"Data is too long: {_this.Length}", nameof(_this));
			}

			string hex = Convert.ToHexString(_this).ToLower(); // TODO: .NET9 use Convert.ToHexStringLower()

			return new YamlScalarNode(hex, true);
		}

		public static void AddTypelessData(this YamlMappingNode mappingNode, string name, byte[] data)
		{
			mappingNode.Add(name, data.Length);
			mappingNode.Add(TypelessdataName, data.ExportYaml());
		}

		public const string TypelessdataName = "_typelessdata";
	}
}
