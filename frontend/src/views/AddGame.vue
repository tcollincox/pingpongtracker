<template>
<div>
  <h1>Add Game</h1>
   <b-container class="bv-example-row">
      <b-row>
         <b-col><AddGame class="top-container"/></b-col>
         <b-col><b-img :src=PaddleAndBall class="paddleImage"></b-img></b-col>
      </b-row>
    </b-container>
</div>
  
</template>

<script>
import AddGame from '@/components/AddGame.vue'

export default {
  components: {
    AddGame
  },
  data(){
    return{
       PaddleAndBall: require("@/images/LargePaddleAndBall.svg")
    }
  }
}
</script>

<style scoped>
h1{
  font-family: 'M PLUS Rounded 1c', sans-serif;
  font-size:400%;
  font-weight: bold;
  margin-top:30px;
}
.paddleImage{
  height: 100%
}
.top-container{
  margin: 50px 0 0 0;
}

</style>