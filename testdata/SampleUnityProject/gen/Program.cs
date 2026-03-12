// Create placeholder .unitypackage files for testing release asset uploads.
// GitHub Releases reject zero-byte files, so we write a small non-empty payload.
var payload = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 };
File.WriteAllBytes($"{Environment.CurrentDirectory}/SampleUnityProject.unitypackage", payload);
File.WriteAllBytes($"{Environment.CurrentDirectory}/SampleUnityProject.Plugin.unitypackage", payload);
