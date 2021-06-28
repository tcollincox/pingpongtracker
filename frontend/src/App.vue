<template>
  <div id="app">
    <div id="nav">
      <b-nav>
      <b-nav-item active class="left"><router-link to="/"><b-img :src="Logo" class="logo"></b-img></router-link></b-nav-item>
      <b-nav-item class="right"><router-link to="/PlayerStats">Stats</router-link></b-nav-item>
      <b-nav-item class="right"><router-link to="/addGame">Add Game</router-link></b-nav-item>
      <b-nav-item class="right"><router-link to="/addPlayer">Add Player</router-link></b-nav-item>
      </b-nav>
    </div>
    <router-view/>
  </div>
</template>
<script>
export default {
   data(){
    return{
       Logo: require("@/images/pingponglogo.svg")
    }
  }
}
</script>
<style>
@import url('https://fonts.googleapis.com/css2?family=M+PLUS+Rounded+1c:wght@300&family=Noto+Sans+JP&display=swap');

#app {
  font-family: 'Noto Sans JP', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  
  background-color: rgb(80, 80, 80);
  font-family: 'M PLUS Rounded 1c', sans-serif;
  font-size: 20px;
}

#nav a {
  font-weight: bold;
  margin: 0 3px 0 3px;
  color: #ffffff;
  text-decoration: none;
}

#nav a.router-link-exact-active {
  color: #a59fff;
}

.right{
  position: relative;
  justify-content: center;
  margin:10px 0 10px 0;
  padding: 15px;
}
.logo{
  height: 80px;
  margin: 0px;
  padding: 0px;
}

</style>
