<template>
  <div class="player">
    <b-container class="bv-example-row">
      <b-row class="row-head">
        <b-col><h4>Games Won</h4></b-col>
        <b-col><h4>Games Lost</h4></b-col>
        <b-col><h4>Total Games</h4></b-col>
        <b-col><h4> Avg PPG</h4></b-col>
      </b-row>
      <b-row class="row-stat">
        <b-col>{{ gamesWon.length }}</b-col>
        <b-col>{{ gamesLost.length }}</b-col>
        <b-col>{{gamesWon.length + gamesLost.length }}</b-col>
        <b-col>{{ Math.round(averagePointsPerGame) }}pts</b-col>
      </b-row>
    </b-container>
    <hr/>
    <div class="page-on">
      <b-container class="page-on-container">
        <b-row class="page-on-row">
          <b-col></b-col>
          <b-row class="page-inc">
            <b-col >
              <div v-if="pageNum>1" class="arrow-box">
                <b-img
                  @click="pageNumOneLess()"
                    :src= leftPointingArrow
                    class="arrow"
                ></b-img>
              </div>
            </b-col>
            <b-col >
            <h2>Page {{pageNum}}</h2>
            </b-col>
            <b-col >
              <div v-if="pageNum<numberOfPages.length" class="arrow-box" >
                <b-img
                    @click="pageNumOneMore()"
                    :src= rightPointingArrow
                    class="arrow"
                ></b-img>
              </div>
            </b-col >
          </b-row>
          <b-col></b-col>
        </b-row>
      </b-container>
    </div>
    <b-table striped 
      :fields="fields" 
      :items="currentTableGames" 
      :per-page="perPage">
    </b-table>
    <b-form-group label="Page" class="label" v-if="numberOfPages.length>1">
          <b-form-select v-model="pageNum" class="form-select" >
            <b-form-select-option v-for="num in numberOfPages" :key="num" :value=num class="option" >{{num}}</b-form-select-option>
          </b-form-select>
    </b-form-group>
   
  </div>
</template>
<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";

Vue.use(VueAxios, axios);

export default {
  name: "PlayerStats",
  props: {
    SpecificPlayerStats: Object,
  },
  data() {
    return {
      GameStats: [],
      TotalPointsWon: 0,
      fields: [{key:"winner.username", sortable: true, label:"Winner"}, "winnerScore" , {key:"loser.username", sortable: true, label:"Loser"} ,"loserScore"],
      perPage: 10,
      totalRows: 1,
      startArrayNum:0,
      endArrayNum:9,
      pageNum:1,
      leftPointingArrow: require("@/images/leftPointingArrow.svg"),
      rightPointingArrow: require("@/images/rightPointingArrow.svg"),
    };
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
    gamesWon: function () {
      return this.playerGames.filter((item) => {
        return item.winner.username === this.SpecificPlayerStats.username;
      });
    },
    gamesLost: function () {
      return this.playerGames.filter((item) => {
        return item.loser.username === this.SpecificPlayerStats.username;
      });
    },
    totalPointsWon: function () {
      return this.gamesWon.reduce((memo, game) => memo + game.winnerScore, 0);
    },
    totalPointsLost: function () {
      return this.gamesLost.reduce((memo, game) => memo + game.loserScore, 0);
    },
    totalPoints: function () {
      return this.totalPointsWon + this.totalPointsLost;
    },
    averagePointsPerGame: function () {
      return this.totalPoints / this.playerGames.length;
    },
    numberOfPages: function(){
      var fullLength = this.playerGames.length
      var numOfPages = Math.ceil(fullLength/10);
      var pages = [];
      for(var i = 0; i<numOfPages; i++){
        pages.push((i+1));
      }
      return pages;
    },
    currentTableGames: function(){
      var fullLength = this.playerGames.length
      var curTableArr = [];
      var startArrayNum = ((10 * this.pageNum) - 10);
      var endArrayNum = ((10 * this.pageNum) - 1);
      if(endArrayNum > fullLength){
        endArrayNum = fullLength-1;
      }
      for(var i = startArrayNum; i<= endArrayNum;i++){
        curTableArr.push(this.playerGames[i]);
      }
      return curTableArr;
    },
  },
  methods:{
    pageNumOneMore:function(){
     this.pageNum = this.pageNum + 1;
    },
    pageNumOneLess:function(){
      this.pageNum = this.pageNum - 1;
    }
  }
};
</script>

<style scoped>
.row-stat{
  font-size: 30px;
}
.col{
  justify-content: center;
}
.label{
  justify-content: center;
  width:150px;
}
.arrow{
  height: 30px;
}
.page-inc{
  width:50%;
}
.page-on-row{
  width:100%;
}
.arrow{
  margin:5px;
}
.arrow-box :hover{
  cursor: pointer;
}
</style>