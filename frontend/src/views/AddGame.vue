<template>
<div>
  <h1>Add Game</h1>
   <b-container class="bv-example-row">
      <b-row>
        
         <b-col><AddGame class="top-container" v-on:animateSubmit="animateOnAndOff"/></b-col>
         <b-col><b-img :src=PaddleAndBall class="paddleImage" v-bind:class="{ 'paddle-animate': isClicked }"></b-img></b-col>
      </b-row>
    </b-container>
</div>
  
</template>

<script>
import AddGame from '@/components/AddGame.vue';

export default {
  data(){
    return{
       PaddleAndBall: require("@/images/LargePaddleAndBall.svg"),
       isClicked: false
    };
  },
  methods:{
    animateOnAndOff:function(){
      this.changeAnimate();
      setTimeout(this.changeAnimate, 1500);
    },
    changeAnimate:function(){
      this.isClicked = !this.isClicked;
    },
  },
  components: {
    AddGame
  },
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
.paddle-animate{
   animation: tada;
  animation-duration: 1s;
}
</style>