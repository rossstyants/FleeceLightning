using UnityEngine;
using System;
using System.Collections.Generic;

namespace Default.Namespace
{
    public enum  TransitionType {
        e_Fade,
        e_WhirlingShape,
        e_Invisible
    }
    public enum  TransitionArea {
        kTransition_World,
        kTransition_Frontend,
        kTransition_Game
    }
    public class Ztransition
    {
		private static Ztransition staticInstance;
        public TransitionType type;
        public bool inTransition;
        public float transitionTimer;
        public int nextState;
        public bool transitionReceding;
        public float transitionAlpha;
        public bool timeToDoStuff;
        public bool nearlyReady;
        public TransitionArea area;
        public Zobject zobject;
        public Zobject spinningWord;
        public Texture2D_Ross pTexture;
        public Texture2D_Ross pBackTexture;
        public bool TimeToDoStuff
        {
            get;
            set;
        }

        public bool InTransition
        {
            get;
            set;
        }

        public TransitionArea Area
        {
            get;
            set;
        }

        public int NextState
        {
            get;
            set;
        }

        public Texture2D_Ross PTexture
        {
            get;
            set;
        }

        public Texture2D_Ross PBackTexture
        {
            get;
            set;
        }

        public Zobject Zobject
        {
            get;
            set;
        }

		public void SetTimeToDoStuff(bool inThing) {timeToDoStuff = inThing;}///@property(readwrite,assign) bool timeToDoStuff; public void SetInTransition(bool inThing) {inTransition = inThing;}///@property(readwrite,assign) bool inTransition;
public void SetArea(TransitionArea inThing) {area = inThing;}///@property(readwrite,assign) TransitionArea area;
public void SetNextState(int inThing) {nextState = inThing;}///@property(readwrite,assign) int nextState;
public void SetPTexture(Texture2D_Ross inThing) 
		{
			pTexture = inThing;
		}////@property(readwrite,assign) Texture2D* pTexture;
public void SetPBackTexture(Texture2D_Ross inThing) {pBackTexture = inThing;}////@property(readwrite,assign) Texture2D* pBackTexture;
public void SetZobject(Zobject inThing) {zobject = inThing;}////@property(readwrite,assign) Zobject* zobject;
//public void SetspinningWord(Zobject inThing) {spinBackground = inThing;}////@property(readwrite,assign) Zobject* spinBackground;

        public static Ztransition GetTransition()
        {
//            static Ztransition staticInstance = null;
            if (staticInstance == null) {
                staticInstance = new Ztransition();
            }

            return staticInstance;
        }

        public Ztransition()
        {
//            //if (!base.init()) return null;

            this.Reset();
            zobject = new Zobject();
            spinningWord = new Zobject();
            pTexture = null;
            //return this;
        }
        public void StartP1P2(int inNextState, TransitionArea inArea, TransitionType inType)
        {
            inTransition = true;
            transitionTimer = 0;
            nextState = inNextState;
            transitionReceding = false;
            nearlyReady = false;
            transitionAlpha = 0;
            area = inArea;
            type = inType;
            this.StartAppearing();
        }

        public void UpdateTransition()
        {
            if (!inTransition) return;

            timeToDoStuff = false;
            this.UpdateTransition_UseZobject();
        }

        public void StartTransition_Fade()
        {
            zobject.SetStretchToScreen(true);
            zobject.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            zobject.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            zobject.SetShowLagSpeed(0.4f);
//			zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
//			zobject.texture.myBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
		}

        public void StartTransition_WhirlingShape()
        {
			Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.GetScreenCentre();
            info.isMapObject = false;
            info.startState = ZobjectState.kZobjectHidden;
            info.texture = pBackTexture;
            spinningWord.Initialise(info);
			spinningWord.SetStretchToScreen(false);
            spinningWord.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_SpinIn);
            spinningWord.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_SpinOut);
			spinningWord.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
            spinningWord.SetShowLagSpeed(0.4f);	
			spinningWord.Show();			
            spinningWord.SetShowLagSpeed(0.4f);	
/*			Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.GetScreenCentre();
            info.isMapObject = false;
            info.startState = ZobjectState.kZobjectHidden;
            info.texture = pBackTexture;
            zobject.Initialise(info);
			zobject.myAtlasBillboard.myObject.layer = LayerMask.NameToLayer("guistuff");
			zobject.SetStretchToScreen(true);
            zobject.SetShowStyle((int) ZobjectShowStyle.kZobjectShow_FadeIn);
            zobject.SetHideStyle((int) ZobjectHideStyle.kZobjectHide_FadeOut);
            zobject.Show();*/
        }

        public void StartAppearing()
        {
            Zobject.ZobjectInfo info = new Zobject.ZobjectInfo() ;
            info.position = Utilities.GetScreenCentre();
            info.isMapObject = false;
            info.startState = ZobjectState.kZobjectHidden;
            info.texture = pTexture;
            zobject.Initialise(info);
            switch (type) {
            case TransitionType.e_Invisible :
                this.StartTransition_Fade();
                zobject.SetTexture(null);
                break;
            case TransitionType.e_Fade :
                this.StartTransition_Fade();
                break;
            case TransitionType.e_WhirlingShape :
                this.StartTransition_WhirlingShape();
                break;
            }

            zobject.Show();
        }

        public void StartReceding()
        {
            zobject.Hide();
            if ((int)type == (int) TransitionType.e_WhirlingShape) spinningWord.Hide();

        }

        public void UpdateTransition_UseZobject()
        {
            if ((int)type == (int) TransitionType.e_WhirlingShape) 
			{
                spinningWord.Update();
            }

            zobject.Update();
            if (!transitionReceding) 
			{
                if (nearlyReady) 
				{
                    timeToDoStuff = true;
                    transitionReceding = true;
                    transitionTimer = 0;
                    this.StartReceding();
                }
                else 
				{
                    if (zobject.state ==  ZobjectState.kZobjectShown) {
                        nearlyReady = true;
                    }

                }

            }
            else {
                if (zobject.state ==  ZobjectState.kZobjectHidden) {
                    inTransition = false;
					if (spinningWord != null)
					{
						spinningWord.Disappear();
					}
                }

            }

        }

        public void Render()
        {
            if (inTransition)
			{
                if ((int)type != (int) TransitionType.e_Invisible) 
				{
                    zobject.Render();
					//Debug.Log ("render transition " + zobject.texture.myMaterial.mainTexture.ToString());					
				}

                if ((int)type == (int) TransitionType.e_WhirlingShape) 
				{
                    spinningWord.Render();
                }
            }
        }

        public void Reset()
        {
            inTransition = false;
        }

    }
}
