import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Player {
    name: string;
    troops: Troops[];
}

interface Troops {
    name: string;
    level: number;
    maxLevel: number;
    village: string;
}

@Component
export default class PlayersComponent extends Vue {
    //forecasts: WeatherForecast[] = [];
    player: Player;
    tag: string;
    homeTroops: Troops[] = [];
    
    mounted() {
        this.tag = this.$route.params["tag"];

        fetch('api/ClashOfClans/Players/' + this.tag)
            .then(response => response.json() as Promise<Player>)
            .then(data => {
                this.player = (data as any);
                //this.homeTroops = this.player.troops.filter(isHome);
            });


    }   
    
}

function isHome(element: Troops, index: number, array: object)
{
    return (element.village == 'home'); 
}
