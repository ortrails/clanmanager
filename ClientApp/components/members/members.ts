import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface MemberViewModel {
    tag: string;
    name: string;
    role: string;
    expLevel: number;
    troopLevel: number;
}

@Component
export default class MembersComponent extends Vue {
    //forecasts: WeatherForecast[] = [];
    items: MemberViewModel[] = [];
    mounted() {
        fetch('api/ClashOfClans/Members')
            .then(response => response.json() as Promise<MemberViewModel[]>)
            .then(data => {
                this.items = (data as any);
            });
    }
}
