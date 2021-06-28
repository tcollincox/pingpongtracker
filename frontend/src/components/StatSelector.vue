<template>
  <div>
      <b-dropdown
        id="selectedStat"
        name="selectedStat"
        v-model="this.chosen"
        :text=this.chosen
        variant="primary"
        class="drop"
      >
        <b-dropdown-item
          v-for="stat in statOptions"
          :key="stat"
          :value="stat"
          @click="
            chosen = stat;
            $emit('not-new');
          "
        >
          {{stat}}
        </b-dropdown-item>
      </b-dropdown>
      
      <div v-if="chosen === 'Games Against' && NewPlayer === false">
        <hr/>
        <GamesAgainst :playerGames='playerGames' :username='SpecificPlayerStats.username'/>
      </div>
      <div v-if="chosen === 'All Games Played' && NewPlayer === false">
        <hr/>
        <GameStats :SpecificPlayerStats="SpecificPlayerStats" />
      </div>
      
    </div>
</template>

<script>
import GameStats from "@/components/GameStats.vue";
import GamesAgainst from "@/components/GamesAgainst.vue";
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
Vue.use(VueAxios, axios);


export default {
  
  props:{
    SpecificPlayerStats : Object,
    NewPlayer : Boolean
  },
  data(){
    return{
      statOptions : ['Games Against', 'All Games Played'],
      chosen : 'Choose A Stat',
      GameStats: [],
      PlayerStatus : this.NewPlayer
    }
  },
   mounted() {
    Vue.axios.get("https://localhost:5001/games/games").then((response) => {
      this.GameStats = response.data;
    });
  },
  computed: {
    playerGames: function () {
      return this.GameStats.filter((item) => {
        return (
          item.winner.username === this.SpecificPlayerStats.username ||
          item.loser.username === this.SpecificPlayerStats.username
        );
      });
    },
  },
  components:{
    GameStats,
    GamesAgainst
  }
}

</script>

<style scoped>
 .dropdown{
   margin: 5px 0 20px 0;
 }
</style>