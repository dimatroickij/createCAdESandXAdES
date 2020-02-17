namespace SignatureMaker.WinForm.Cades
{
	/// <summary>
	/// Кастомный десериализатор из base64, хз зачем
	/// </summary>
    public static class Base64
    {
		// =bease64=
		// "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
		private static readonly byte[] Code =
		{
			//   0    1    2    3    4    5    6    7    8    9    A    B    C    D    E    F  
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // 0
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // 1
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 62, 255, 255, 255, 63, // 2
			52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 255, 255, 255, 255, 255, 255, // 3
			255, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, // 4
			15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 255, 255, 255, 255, 255, // 5
			255, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, // 6
			41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 255, 255, 255, 255, 255, // 7
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // 8
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // 9
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // A
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // B
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // C
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // D
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // E
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, // F
		};

		public static bool FromBase64ToByteArray(byte[] base64, out long resLength, byte[] resArray = null)
		{
			resLength = 0;
			if (base64 == null) return false;

			long offset = 0, headOffset = 0, resOffset = 0;
			var bc = 0;
			long buf = 0;
			var len = base64.LongLength;
			while (offset < len)
			{
				byte s = base64[offset], res;
				if ((res = Code[s]) != 255)
				{
					buf <<= 6;
					buf += res;
					bc++;
					if (bc == 4)
					{
						if (resArray != null)
						{
							var b2 = (byte) (buf & 0xff);
							buf >>= 8;
							var b1 = (byte) (buf & 0xff);
							buf >>= 8;
							var b0 = (byte) (buf & 0xff);
							buf >>= 8;
							resArray[resOffset++] = b0;
							resArray[resOffset++] = b1;
							resArray[resOffset++] = b2;
						}
						else
							resOffset += 3;

						bc = 0;
					}
				}
				else if (s == 0x2D)
				{
					var firstTime = headOffset == 0;
					headOffset = 0;
					while (offset < len && headOffset < 5 && base64[offset] == 0x2D)
					{
						offset++;
						headOffset++;
					}

					if (headOffset < 5) return false;
					while (offset < len && base64[offset] != 0x2D)
						offset++;
					headOffset = 1;
					while (offset < len && headOffset < 5 && base64[offset] == 0x2D)
					{
						offset++;
						headOffset++;
					}

					if (headOffset < 5) return false;
					if (!firstTime) break;
				}
				else if (s == 0x0A || s == 0x0D || s == 0x20 || s == 0x09)
				{
				}
				else if (s == 0x3D /* = */)
				{
					var pc = 1;
					offset++;
					if (offset < len)
					{
						if (base64[offset] == 0x3D) pc++;
					}

					if (pc == 2)
					{
						if (resArray != null)
							resArray[resOffset++] = (byte) (buf >> 4);
						else
							resOffset++;
					}
					else
					{
						if (resArray != null)
						{
							buf >>= 2;
							var b1 = (byte) (buf & 0xff);
							buf >>= 8;
							var b0 = (byte) (buf & 0xff);
							resArray[resOffset++] = b0;
							resArray[resOffset++] = b1;
						}
						else
							resOffset += 2;
					}

					break;
				}
				else return false;

				offset++;
			}

			resLength = resOffset;
			return true;
		}
		// =====
    }
}