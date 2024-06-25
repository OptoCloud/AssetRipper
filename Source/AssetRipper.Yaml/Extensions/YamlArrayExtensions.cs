using System.Text;

namespace AssetRipper.Yaml.Extensions
{
	public static class YamlArrayExtensions
	{
		public static YamlNode ExportYaml(this byte[] _this)
		{
			return new YamlScalarNode(_this);
		}

		public static void AddTypelessData(this YamlMappingNode mappingNode, string name, byte[] data)
		{
			mappingNode.Add(name, data.Length);
			mappingNode.Add(TypelessdataName, data.ExportYaml());
		}

		public const string TypelessdataName = "_typelessdata";
	}
}
