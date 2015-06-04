import Ember from "ember";

export default Ember.ArrayController.extend({
	newestPost: [],
	actions: {},
	getNewestPost: function(){
		var apiUrl = "http://localhost:55882/Posts/GetPosts",
			control = this;	

		Ember.$.ajax({
			url: apiUrl,
			dataType: "json",
		}).complete (function(data){
			control.set("newestPost", data.responseJSON);
		});
	}
});