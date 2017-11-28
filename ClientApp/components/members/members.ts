import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Items {
    tag: string;
    name: string;
    role: string;
    expLevel: number;
}

@Component
export default class MembersComponent extends Vue {
    //forecasts: WeatherForecast[] = [];
    items: Items[] = [];
    mounted() {
        fetch('api/ClashOfClans/Members')
            .then(response => response.json() as Promise<Items[]>)
            .then(data => {
                this.items = (data as any).items;
            });
    }
}
