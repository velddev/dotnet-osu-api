﻿using System.Threading.Tasks;
using Xunit;
using Veld.Osu.V1;
using RichardSzalay.MockHttp;
using System.Net.Http;

namespace Veld.Osu.Tests.V1;

public class GetPlayerTests
{
    [Fact]
    public async Task GetPlayerTest()
    {
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("get_user")
            .Respond("application/json", "[{\"user_id\":\"3799147\",\"username\":\"Veld\",\"join_date\":\"2013-12-29 20:06:35\",\"count300\":\"3808444\",\"count100\":\"511291\",\"count50\":\"73706\",\"playcount\":\"21774\",\"ranked_score\":\"7845282719\",\"total_score\":\"25533528144\",\"pp_rank\":\"68635\",\"level\":\"99.8485\",\"pp_raw\":\"3806.47\",\"accuracy\":\"97.83573150634766\",\"count_rank_ss\":\"44\",\"count_rank_ssh\":\"7\",\"count_rank_s\":\"590\",\"count_rank_sh\":\"46\",\"count_rank_a\":\"661\",\"country\":\"NL\",\"total_seconds_played\":\"1260698\",\"pp_country_rank\":\"997\",\"events\":[{\"display_html\":\"<img src='/images/A_small.png'/>\",\"beatmap_id\": \"222342\",\"beatmapset_id\":\"54851\",\"date\":\"2013-07-07 22:34:04\",\"epicfactor\":\"1\"}, {\"display_html\":\"<img src='/images/A_small.png'/>\",\"beatmap_id\": null,\"beatmapset_id\":null,\"date\":\"2013-07-07 22:34:04\",\"epicfactor\":\"1\"}]}]");

        IOsuApiClient client = new OsuApiClientV1("some-fake-key", new HttpClient(mockHttp));

        var player = await client.GetPlayerAsync("veld");

        Assert.Equal(3799147, player.UserId);
        Assert.Equal("Veld", player.Username);
        Assert.NotEmpty(player.Events);
    }
}
