package pl.opole.uni.lista1.model;

import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@DiscriminatorValue("koszula")
@Table(name="koszula")
public class Koszula extends Ubranie{
    private Boolean czy_guziki;
    private Boolean czy_dlugi_rekaw;
    private String rodzaj_kolniezyka;

    public Boolean getCzy_guziki() {
        return czy_guziki;
    }

    public void setCzy_guziki(Boolean czy_guziki) {
        this.czy_guziki = czy_guziki;
    }

    public Boolean getCzy_dlugi_rekaw() {
        return czy_dlugi_rekaw;
    }

    public void setCzy_dlugi_rekaw(Boolean czy_dlugi_rekaw) {
        this.czy_dlugi_rekaw = czy_dlugi_rekaw;
    }

    public String getRodzaj_kolniezyka() {
        return rodzaj_kolniezyka;
    }

    public void setRodzaj_kolniezyka(String rodzaj_kolniezyka) {
        this.rodzaj_kolniezyka = rodzaj_kolniezyka;
    }
}
