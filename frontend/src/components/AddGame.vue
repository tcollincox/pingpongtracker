<template>
  <div>
     <b-card header-tag="header" >
      <template #header>
        <h3 class="mb-0">Enter Game Results</h3>
      </template>
        <p v-if="validation" class="validation-text">*Winner and Loser cannot be the same player</p>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
          <b-form-group label="Select Winner" class="label">
            <b-form-select v-model="form.selectedPlayerWinner" class="form-select">
            <b-form-select-option v-for="player in PlayerList" :key="player.username" :value=player >{{player.username}}</b-form-select-option>
            </b-form-select>
          </b-form-group>

          <b-form-group
            id="winner-score"
            label="Winner Score"
            label-for="winner-score"
            class="label"
          >
            <b-form-input
              id="winner-score"
              v-model="form.winnerScore"
              type="number"
              required
            ></b-form-input>
          </b-form-group>
          
          <b-form-group label="Select Loser" class="label">
            <b-form-select v-model="form.selectedPlayerLoser" class="form-select">
            <b-form-select-option v-for="player in PlayerList" :key="player.username" :value=player >{{player.username}}</b-form-select-option>
            </b-form-select>
          </b-form-group>

          <b-form-group
            id="loser-score"
            label="Loser Score"
            label-for="loser-score"
            class="label"
          >
            <b-form-input
              id="loser-score"
              v-model="form.loserScore"
              type="number"
              required
            ></b-form-input>
          </b-form-group>

          <b-button type="submit" variant="primary">Submit</b-button>
          <b-button type="reset" variant="danger">Reset</b-button>
        </b-form>
     </b-card>
  </div>
</template>

<script>
import Vue from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
Vue.use(VueAxios, axios);

export default {
  data() {
    return {
      form: {
        winnerScore: 21,
        loserScore: 0,
        selectedPlayerWinner: [],
        selectedPlayerLoser: []
      },
      show: true,
      PlayerList: [],
      validation: false,
    };
  },
  mounted() {
    Vue.axios.get("https://localhost:5001/player/player").then((response) => {
      this.PlayerList = response.data;
    });
  },
  methods: {
    onSubmit() {
      if(this.form.selectedPlayerWinner != this.form.selectedPlayerLoser && this.form.selectedPlayerWinner != null && this.form.selectedPlayerLoser != null){
      let newGame = {
        winner: this.form.selectedPlayerWinner,
        loser: this.form.selectedPlayerLoser,
        winnerScore: this.form.winnerScore,
        loserScore: this.form.loserScore,
      };
        Vue.axios
          .post("https://localhost:5001/games/addGame", newGame)
          .catch((error) => {
            console.log(error);
          });
        this.form.selectedPlayerLoser = null;
        this.form.selectedPlayerWinner = null;
        this.form.winnerScore = 21;
        this.form.loserScore = 0;
        this.validation = false;
        this.$emit('animateSubmit');
      }
      else{
        this.validation = true;
      }
    },
    onReset(event) {
      event.preventDefault();
      // Reset our form values
      this.form.selectedPlayerLoser = null;
      this.form.selectedPlayerWinner = null;
      this.form.winnerScore = 21;
      this.form.loserScore = 0;
      this.validation = false;
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
  },
};
</script>

<style scoped>
button {
  margin: 10px 5px 5px 5px;
}
.form-select{
  justify-content: center;
}
.label{
  font-size: 20px;
}
.form-group{
  margin: 10px 0 10px 0;
}
.validation-text{
  color: red;
}
.submitted{
  height: 100%;
}

</style>