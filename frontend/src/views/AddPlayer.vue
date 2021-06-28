<template>
  <div>
    <h1>Add Player</h1>
    <b-container >
      <b-row>
        <b-col class="formArea"><AddPlayer /></b-col>
        <b-col>
          <b-img
            :src= PaddleAndBall
            class="paddleImage"
          ></b-img>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import AddPlayer from "@/components/AddPlayer.vue";

export default {
  components: {
    AddPlayer,
  },
  data(){
    return{
      PaddleAndBall: require("@/images/LargePaddleAndBall.svg"),
    }
  },
}
</script>

<style scoped>
.paddleImage {
  height: 100%;
}
h1{
  font-family: 'M PLUS Rounded 1c', sans-serif;
  font-size:400%;
  font-weight: bold;
  margin-top:30px;
}
.formArea{
 margin-top: 30px;
}
</style>

