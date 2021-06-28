<template>
  <div class="home">
    <h1>Ping Pong Tracker</h1>
    <div class="top-button">
      <b-button variant="primary" @click="$router.push('AddGame')">Add Game</b-button>
      <b-button variant="danger" @click="$router.push('AddPlayer')">Add New Player</b-button>
    </div>
    <div>
      <b-img :src="require('../images/pingpongtable.jpg')"></b-img>
    </div>
    <div class="bottom-button">
      <b-button variant="outline-primary" @click="$router.push('PlayerStats')">See Player Stats</b-button>
    </div>
    
  </div>

</template>

<script>
// @ is an alias to /src


export default {
  name: 'Home',
  data () {
    return{

    }
  }
}
</script>

<style scoped>
  button{
    margin-inline: 15px;
  }

  h1{
  font-family: 'M PLUS Rounded 1c', sans-serif;
  font-size:400%;
  font-weight: bold;
  margin-bottom: 30px;
  margin-top:30px;
  }
  
  img{
    margin: 30px 0 30px 0;
  }
</style>
