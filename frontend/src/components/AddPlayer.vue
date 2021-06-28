<template>
  <div>
     <b-card header-tag="header" >
      <template #header>
        <h3 class="mb-0">Enter Player Info</h3>
      </template>
      <p v-if="validationCheck" class="validation-check">*This username already exists. Please choose a different one.</p>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
          <b-form-group id="name-input" label="Player Name" label-for="name-input" class="label">
            <b-form-input
              id="name-input"
              v-model="form.name"
              type="text"
              placeholder="Enter Name"
              required
            ></b-form-input>
          </b-form-group>

          <b-form-group
            id="UserName-input"
            label="UserName"
            label-for="UserName-input"
            class="label"
          >
            <b-form-input
              type="text"
              id="UserName input"
              v-model="form.userName"
              placeholder="Enter UserName"
              required
              
            ></b-form-input>
          </b-form-group>

          <b-form-group id="color-input" label="Color:" label-for="color-input" class="label">
            <b-form-select
              id="color-input"
              v-model="form.color"
              :options="colors"
              required
              class="form-select"
            ></b-form-select>
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
        name: "",
        userName: "",
        color: null,
      },
      colors: [
        { text: "Select One", value: null },
        "Red",
        "Green",
        "Blue",
        "Orange",
      ],
      show: true,
      existingPlayers: [],
      validationCheck: false,
    };
  },
  mounted() {
    Vue.axios.get("https://localhost:5001/player/player").then((response) => {
      this.existingPlayers = response.data;
    });
  },
  methods: {
    onSubmit() {
      if(this.matchingNameCheck(this.form.userName)){
        let newPlayer = {
          name: this.form.name,
          userName: this.form.userName,
          color: this.form.color,
        };
        Vue.axios
          .post("https://localhost:5001/player/addPlayer", newPlayer)
          .catch((error) => {
            console.log(error);
          });
          this.form.name= ""
          this.form.userName= ""
          this.form.color= null
          this.validationCheck = false;
      }
      else{
        this.validationCheck = true;
      }
    },
    onReset(event) {
      event.preventDefault();
      this.form.name = "";
      this.form.userName = "";
      this.form.color = null;
      this.validationCheck = false;
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    },
    matchingNameCheck(name){
      let matchingName = this.existingPlayers
        .filter((player) => {
          return player.username === name;
        })
      if(matchingName.length > 0){
        return false;
      }
      else{
        return true;
        
      }
    }
  },
};
</script>

<style scoped>
button {
  margin: 10px 5px 5px 5px;
}
.form-group{
  margin: 15px 0 15px 0;
}
.form-select{
  justify-content: center;
}
.label{
  font-size: 20px;
}
.validation-check{
  color: red;
}
</style>