//graph
var Chart = function() {
    this.parent;
    this.values = new Array();
    this.rate = 0;
    this.max = -1.0;
    this.form = "<div style='position:relative;width:<SIZE>%;height:100%;background-color:#FFFF99;'>";
    this.getMax = function(value) {
        if (this.max < value * 1.0) {
            this.max = value;
        }
    };

    this.getRate = function() {
        this.rate = 100 / this.max;
    }
    this.fire = function(id, pos) {
        this.parent = document.getElementById(id);
        //alert(this.parent.children[0].innerHTML);
        var max = this.parent.children[0].children.length;

        for (var i = 1; i < max; i++) {
            this.values[i - 1] = this.parent.children[0].children[i].children[pos].innerHTML;
            this.getMax(this.values[i - 1]);
        }
        this.getRate();
        this.draw(pos);
        //alert(this.values + "\n" + this.max + "\n" + this.rate);
    };

    this.draw = function(pos) {
        var max = this.parent.children[0].children.length;
        for (var i = 1; i < max; i++) {
            var chart = this.form.replace("<SIZE>", this.values[i - 1] * this.rate);
            //alert(this.values[i-1] * this.rate);
            this.parent.children[0].children[i].children[pos].innerHTML = chart + this.parent.children[0].children[i].children[pos].innerHTML;

        }

    }
}