using System.Runtime.InteropServices;
using DirectN;

namespace Command.Records;

internal struct SpecificationVal
{
	internal string Path;

	internal D3D11_TEXTURE2D_DESC Description;

	internal D3D11_SUBRESOURCE_DATA watcherVal;

	internal GCHandle _ReponseVal;
}
