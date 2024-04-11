package pl.opole.uni.lista1.model;

import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.criteria.CriteriaBuilder;

@Entity
@DiscriminatorValue("spodnie")
@Table(name="spodnie")
public class Spodnie extends Ubranie{
    private Boolean czy_jeans;
    private String rodzaj_nogawki;
    private Integer ile_kieszenie;

    public Boolean getCzy_jeans() {
        return czy_jeans;
    }

    public void setCzy_jeans(Boolean czy_jeans) {
        this.czy_jeans = czy_jeans;
    }

    public String getRodzaj_nogawki() {
        return rodzaj_nogawki;
    }

    public void setRodzaj_nogawki(String rodzaj_nogawki) {
        this.rodzaj_nogawki = rodzaj_nogawki;
    }

    public Integer getIle_kieszenie() {
        return ile_kieszenie;
    }

    public void setIle_kieszenie(Integer ile_kieszenie) {
        this.ile_kieszenie = ile_kieszenie;
    }
}
