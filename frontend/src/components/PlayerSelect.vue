<template>
  <div class="player">
    <div>
          <b-dropdown
            id="playername"
            name="playername"
            v-model="this.username"
            :text=username
            variant="primary"
            class="drop"
          >
            <b-dropdown-item
              v-for="playerStat in PlayerStats"
              :key="playerStat.username"
              :value="playerStat.username"
              @click="
                username = playerStat.username;
                selectedPlayer();
                NewPlayer = true
              "
            >
              {{ playerStat.username }}
            </b-dropdown-item>
          </b-dropdown>
           <div v-if="specificHasValue">
           <p>
            {{this.SpecificPlayerStats.name }} | 
            "{{this.SpecificPlayerStats.username}}" |
            {{this.SpecificPlayerStats.color }}
            </p>
            </div>
          <div v-if="specificHasValue">
           
            <StatSelector 
              :SpecificPlayerStats="SpecificPlayerStats"
              :NewPlayer = "NewPlayer"
              v-on:not-new="NewPlayer = false"
            />
    </div>

      
    </div>
    
    
  </div>
</template>
<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
Vue.use(VueAxios, axios);


import StatSelector from "@/components/StatSelector.vue";

export default {
  name: "PlayerSelect",
  data() {
    return {
      PlayerStats: [],
      SpecificPlayerStats: Object,
      username: "Choose A Player",
      specificHasValue: false,
      NewPlayer : false
    };
  },
  mounted() {
    Vue.axios.get("https://localhost:5001/player/player").then((response) => {
      this.PlayerStats = response.data;
    });
  },
  methods: {
    selectedPlayer() {
      this.SpecificPlayerStats = this.PlayerStats.find(
        (p) => p.username === this.username
      );
      this.specificHasValue = true;
    },
  },
  components: {
    StatSelector
  },
};
</script>

<style scoped>
btn {
  margin: 5px 5px 5px 5px;
}
.drop {
  margin: 10px 0 20px 0;
}
</style>