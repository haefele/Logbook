"use strict";

import {autoinject} from "aurelia-framework";
import {SummonersService} from "services/summoners-service";
import {Summoner} from "api/models/summoner";
import {Region} from "api/models/region";
import {IAddSummonerData} from "components/add-summoner";

@autoinject()
export class SummonerOverview {
    
    public summoners: Summoner[];
    
    public constructor(private summonersService: SummonersService) {
    }
    
    public async activate(): Promise<void> {
        let summoner = new Summoner();
        summoner.id = 123;
        summoner.name = "haefele";
        summoner.region = Region.euw;
        
        let summoners = await this.summonersService.getSummoners();
        this.summoners = summoners.concat(summoner);
    }
    
    public addSummoner(data: IAddSummonerData) : void {
        alert(`${data.region} ${data.summonerName}`);
    }
}
