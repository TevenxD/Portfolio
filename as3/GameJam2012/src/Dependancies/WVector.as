package src.Dependancies 
{
	import flash.display.Sprite;
    import flash.events.Event;
 
    public class WVector extends Sprite
    {
		//private var pijl:Pijl;
        private var _dx:Number;
        private var _dy:Number;
        private var _r:Number;
        private var _hoek:Number;
		
		private var pijlPunt:Sprite;
		private var pijlBody:Sprite;
		public var kleur:uint;
		public var vergroting:Number = 1;
		
		private var h:Number = 4;
		private var ha:Number = 10;
		private var wa:Number = 20;
 
        public function WVector(dx:Number = NaN, dy:Number = NaN)
        {
            this._dx = dx;
            this._dy = dy;
            this._r =  this.rechthoek2pool(dx,dy)[0];
            this._hoek = this.rechthoek2pool(dx,dy)[1];
        }
 
        public function get dx(): Number
        {
            return this._dx;
        }
 
        public function get dy(): Number
        {
            return this._dy;
        }
 
        public function get r(): Number
        {
            return this._r;
        }
 
        public function get hoek(): Number
        {
            return this._hoek;
        }
 
        public function set hoek(hoek:Number): void
        {
            this._hoek = hoek;
            this._dx = this.pool2rechthoek(this._r, this._hoek)[0];
            this._dy = this.pool2rechthoek(this._r, this._hoek)[1];
        }
 
        public function set dx(dx:Number):void
        {
            this._dx = dx;
            this._r = this.rechthoek2pool(this._dx, this._dy)[0];
            this._hoek = this.rechthoek2pool(this._dx, this._dy)[1];
        }
 
        public function set dy(dy:Number):void
        {
            this._dy = dy;
            this._r = this.rechthoek2pool(this._dx, this._dy)[0];
            this._hoek = this.rechthoek2pool(this._dx, this._dy)[1];
        }
 
        public function set r(r:Number):void
        {
            this._r = r;
            this._dx = this.pool2rechthoek(this._r, this._hoek)[0];
            this._dy = this.pool2rechthoek(this._r, this._hoek)[1];
        }
 
        public function rechthoek2pool(dx:Number, dy:Number):Array
        {
            var antwoord:Array = new Array();
            antwoord[0]=Math.sqrt((dx*dx) + (dy*dy));
            antwoord[1]= Math.atan2(dy,dx);
            return antwoord;
        }
 
        public function pool2rechthoek(r:Number, hoek:Number):Array
                {
            var antwoord:Array = new Array();
            antwoord[0]=r*Math.cos(hoek);
            antwoord[1]=r*Math.sin(hoek);
            return antwoord;
        }
 
		public function telOp(vector:WVector):void
		{
			this.dx += vector.dx;
			this.dy += vector.dy;
		}

		public function teken(kleur:uint, vergroting:Number):void
		{
				this.vergroting = vergroting;
				this.kleur = kleur;
				pijlBody = tekenBody();
				pijlPunt = tekenPunt();
				
				addChild(pijlBody);
				addChild(pijlPunt);
				addEventListener(Event.ENTER_FRAME, loop);
		}

		private function loop(e:Event):void
		{
				refreshBody();
				this.pijlBody.rotation = this.hoek * 180 / Math.PI;
				this.pijlPunt.rotation = this.hoek * 180 / Math.PI;
				this.pijlPunt.x = this.dx * vergroting;
				this.pijlPunt.y = this.dy * vergroting;
		}

		private function tekenPunt():Sprite
		{
				var antwoord:Sprite = new Sprite();
				antwoord.graphics.clear();
				antwoord.graphics.beginFill(kleur);
				antwoord.graphics.lineStyle();
				antwoord.graphics.moveTo(0, 0);
				antwoord.graphics.lineTo(-wa, -ha);
				antwoord.graphics.lineTo(-wa, ha);

				antwoord.graphics.lineTo(0, 0);
				antwoord.graphics.endFill();

				antwoord.graphics.lineStyle(2);
				antwoord.graphics.moveTo(-wa, -h);
				antwoord.graphics.lineTo(-wa, -ha);
				antwoord.graphics.lineTo(0, 0);
				antwoord.graphics.lineTo(-wa, ha);
				antwoord.graphics.lineTo(-wa, h);
				return antwoord;
		}

		private function tekenBody():Sprite
		{
				var antwoord:Sprite = new Sprite();
				antwoord.graphics.clear();
				antwoord.graphics.beginFill(kleur);
				antwoord.graphics.drawRect( 0, -h, this.r*vergroting-wa, 2 * h);
				antwoord.graphics.endFill();

				antwoord.graphics.lineStyle(2);
				antwoord.graphics.moveTo(this.r*vergroting-wa, h);
				antwoord.graphics.lineTo(0, h);
				antwoord.graphics.lineTo(0, -h);
				antwoord.graphics.lineTo(this.r*vergroting-wa, -h);
				return antwoord
		}

		private function refreshBody():void
		{
				pijlBody.graphics.clear();
				pijlBody.graphics.beginFill(kleur);
				pijlBody.graphics.drawRect( 0, -h, this.r*vergroting-wa, 2 * h);
				pijlBody.graphics.endFill();

				pijlBody.graphics.lineStyle(2);
				pijlBody.graphics.moveTo(this.r*vergroting-wa, h);
				pijlBody.graphics.lineTo(0, h);
				pijlBody.graphics.lineTo(0, -h);
				pijlBody.graphics.lineTo(this.r*vergroting-wa, -h);
		}
 
 
    }
}