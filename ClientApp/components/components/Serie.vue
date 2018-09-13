<template>
    <v-flex xs3 style="display: inline-block; margin: 1.9%;">
            <v-card color="teal lighten-5" class="white--text">
                <router-link :to="{ name: 'seriedetail', params: { id: serieId }}" style="text-decoration: none;">
                    <v-layout>
                        <v-flex xs5>
                            <v-img
                            :src="imageUrl"
                            height="146px"
                            contain
                            ></v-img>
                        </v-flex>
                        <v-flex xs7>
                            <v-card-title primary-title>
                            <div>
                                <div class="headline" style="color: black">{{title}}</div>
                                <div style="color: black">{{description}}</div>
                            </div>
                            </v-card-title>
                        </v-flex>
                    </v-layout>
                </router-link>
                <v-divider light></v-divider>
                <v-card-actions style="color: black" class="pa-3">
                Rate this serie
                <v-spacer></v-spacer>
                <span  style="color: black">
                    ({{ rating }})
                </span>
                <v-rating 
                    style="z-index: 100"
                    v-model="rating"
                    background-color="black"
                    color="yellow accent-4"
                    dense
                    hover
                    size="18"
                ></v-rating>
                </v-card-actions>
            </v-card>
    </v-flex>
</template>

<script>
  export default {
    props: ['serieId', 'title', 'description', 'imageUrl', 'ratingValue'],
    data: function () {
        return {
            rating: this.ratingValue
        }
    }
  }
</script>

<style>

</style>
