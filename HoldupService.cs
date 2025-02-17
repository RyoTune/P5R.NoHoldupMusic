namespace P5R.NoHoldupMusic;

internal class HoldupService
{
    private delegate void PlayBgm(int param_1);
    private PlayBgm? _playBgm;

    private delegate void FUN_140b4e9b0(nint param_1, nint param_2);
    private readonly SHFunction<FUN_140b4e9b0>? _FUN_140b4e9b0Hook;

    public HoldupService()
    {
        ScanHooks.Add(nameof(PlayBgm), "40 53 48 83 EC 30 89 CB", (hooks, result) => _playBgm = hooks.CreateWrapper<PlayBgm>(result, out _));
        _FUN_140b4e9b0Hook = new SHFunction<FUN_140b4e9b0>(FUN_140b4e9b0Impl, "48 8B C4 48 89 50 ?? 48 89 48 ?? 55 56 48 8D 68");
    }

    private void FUN_140b4e9b0Impl(nint param_1, nint param_2)
    {
        //Log.Information(nameof(FUN_140b4e9b0));
        _playBgm!(341);
        _FUN_140b4e9b0Hook!.OriginalFunction(param_1, param_2);
    }
}
