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
    player: Player;
    tag: string;
    homeTroops: Troops[] = [];
    troopLevel: number = 0;

    data() {
        return {
            tag: this.$route.params["tag"],
            player: { name: 'test'}
    } }

    mounted() {
        this.tag = this.$route.params["tag"];
        fetch('api/ClashOfClans/Players/' + this.tag)
            .then(response => response.json() as Promise<Player>)
            .then(data => {
                this.player = data;
                this.homeTroops = this.player.troops.filter(isHome);
                for (var i = 0; i < this.homeTroops.length; i++) {
                    console.log(this.homeTroops[i].name + ':' + this.homeTroops[i].level);
                    this.troopLevel += this.homeTroops[i].level;
                }
                console.log(this.troopLevel);
            });
    }
}

function isHome(element: Troops, index: number, array: object) {
    return (element.village == 'home');
}
